using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace lab1
{
    internal class WordHelper
    {
        private FileInfo _fileInfo;

        public WordHelper(string filename) 
        {
            if (File.Exists(filename)) 
            {
                _fileInfo = new FileInfo(filename);
            }
            else 
            {
                throw new ArgumentException("Файл не найден!");
            }
        }

        internal bool Process(Dictionary<string, string> items, string imagePath)
        {
            try 
            {
                var app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                var document = app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing,
                        Replace: replace);
                }

                foreach (Word.Range range in document.StoryRanges)
                {
                    while (range.Find.Execute("<image>"))
                    {
                        // Вставляем изображение
                        Word.InlineShape inlineShape = range.InlineShapes.AddPicture(imagePath);
                        inlineShape.Width = 100; // Устанавливаем желаемую ширину изображения
                        inlineShape.Height = 100; // Устанавливаем желаемую высоту изображения

                        // Устанавливаем параметры обтекания текстом
                        inlineShape.ConvertToShape().WrapFormat.Type = Word.WdWrapType.wdWrapThrough; // Обтекание текстом
                        inlineShape.ConvertToShape().WrapFormat.Side = Word.WdWrapSideType.wdWrapBoth; // Обтекание со всех сторон
                        inlineShape.ConvertToShape().WrapFormat.AllowOverlap = -1; // Разрешить наложение

                        range.Find.Execute("<image>", Replace: Word.WdReplace.wdReplaceOne);
                    }
                }

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
    }
}

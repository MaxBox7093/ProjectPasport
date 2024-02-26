using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    internal class FileDialog
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        public FileDialog(System.Windows.Forms.PictureBox pictureBox1)
        {
            this.pictureBox1 = pictureBox1;
        } 
        public void OpenFileImg() 
        {
            Form1 form = new Form1();
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap originalImage = new Bitmap(open_dialog.FileName);

                    // Создаем новый Bitmap с нужным размером
                    Bitmap resizedImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                    // Используем Graphics для отрисовки оригинального изображения на новом Bitmap с нужным размером
                    using (Graphics g = Graphics.FromImage(resizedImage))
                    {
                        g.DrawImage(originalImage, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    }

                    // Освобождаем ресурсы оригинального изображения
                    originalImage.Dispose();

                    // Присваиваем новое изображение pictureBox1
                    pictureBox1.Image = resizedImage;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

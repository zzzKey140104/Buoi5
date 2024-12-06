using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void taoMoiVanBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void moTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }   
        }

        private void luuVanBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm tất cả các font hệ thống vào ComboBox
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name);
            }
            // Đặt font mặc định
            comboBoxFont.SelectedItem = "Tahoma"; // Font mặc định trong giao diện của bạn
                                                  // Thêm các kích thước chữ vào ComboBox
            for (int i = 8; i <= 48; i += 2) // Thêm size từ 8 đến 48
            {
                comboBoxSize.Items.Add(i);
            }
            // Đặt size mặc định
            comboBoxSize.SelectedItem = 14; // Size mặc định
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn tạo mới văn bản không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                richTextBox1.Clear();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt",
                Title = "Lưu văn bản"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                {
                    // Lưu dưới dạng RTF
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    // Lưu dưới dạng Text
                    System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                }
                MessageBox.Show("Văn bản đã được lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có văn bản được chọn
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font; // Dùng font mặc định nếu SelectionFont là null
                FontStyle newStyle = currentFont.Style;

                // Đổi trạng thái in đậm
                if (currentFont.Bold)
                    newStyle &= ~FontStyle.Bold; // Loại bỏ in đậm
                else
                    newStyle |= FontStyle.Bold; // Thêm in đậm

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
            else
            {
                MessageBox.Show("Hãy bôi đen văn bản trước khi thay đổi định dạng!", "Thông báo");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
                FontStyle newStyle = currentFont.Style;

                // Đổi trạng thái in nghiêng
                if (currentFont.Italic)
                    newStyle &= ~FontStyle.Italic; // Loại bỏ in nghiêng
                else
                    newStyle |= FontStyle.Italic; // Thêm in nghiêng

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
            else
            {
                MessageBox.Show("Hãy bôi đen văn bản trước khi thay đổi định dạng!", "Thông báo");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
                FontStyle newStyle = currentFont.Style;

                // Đổi trạng thái gạch chân
                if (currentFont.Underline)
                    newStyle &= ~FontStyle.Underline; // Loại bỏ gạch chân
                else
                    newStyle |= FontStyle.Underline; // Thêm gạch chân

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
            else
            {
                MessageBox.Show("Hãy bôi đen văn bản trước khi thay đổi định dạng!", "Thông báo");
            }
        }

        private void dinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng FontDialog
            FontDialog fontDialog = new FontDialog();

            // Thiết lập font hiện tại của RichTextBox nếu đã có nội dung
            if (richTextBox1.SelectionFont != null)
            {
                fontDialog.Font = richTextBox1.SelectionFont;
            }

            // Hiển thị hộp thoại chọn font
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Áp dụng font được chọn vào văn bản trong RichTextBox
                richTextBox1.SelectionFont = fontDialog.Font;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFont_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) // Kiểm tra xem có bôi đen văn bản hay không
            {
                string selectedFont = comboBoxFont.SelectedItem.ToString(); // Lấy font chữ đã chọn từ ComboBox

                try
                {
                    // Lấy font hiện tại của đoạn văn bản đã bôi đen
                    Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;

                    // Cập nhật font của đoạn văn bản đã bôi đen
                    richTextBox1.SelectionFont = new Font(selectedFont, currentFont.Size, currentFont.Style);
                }
                catch (Exception)
                {
                    MessageBox.Show("Font không hợp lệ!", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Hãy bôi đen văn bản trước khi thay đổi font!", "Thông báo");
            }
        }

        private void comboBoxSize_DropDownClosed(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) // Kiểm tra xem có bôi đen văn bản hay không
            {
                // Kiểm tra xem giá trị người dùng chọn có hợp lệ không
                if (float.TryParse(comboBoxSize.SelectedItem.ToString(), out float selectedSize))
                {
                    try
                    {
                        // Lấy font hiện tại của đoạn văn bản đã bôi đen
                        Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;

                        // Cập nhật kích thước chữ cho đoạn văn bản đã bôi đen
                        richTextBox1.SelectionFont = new Font(currentFont.FontFamily, selectedSize, currentFont.Style);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kích thước không hợp lệ!", "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn kích thước hợp lệ!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy bôi đen văn bản trước khi thay đổi kích thước!", "Thông báo");
            }
        }
    }
}

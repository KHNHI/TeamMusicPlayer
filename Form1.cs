using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
          // axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
        }
        OpenFileDialog openFileDialog;
        string[] filePaths;
        string[] fileNames;
        private void btnSwap_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (doublyLinkedList.Current != null)
            {
                // Di chuyển đến bài hát tiếp theo
                doublyLinkedList.MoveNext();

                // Kiểm tra nếu đã đến bài hát cuối cùng
                if (doublyLinkedList.Current == null)
                {
                    // Nếu đã hết playlist, quay lại bài hát đầu tiên
                    doublyLinkedList.Current = doublyLinkedList.Head;
                }

                // Phát bài hát tiếp theo hoặc quay lại đầu tiên
                if (doublyLinkedList.Current != null)
                {
                    axWindowsMediaPlayer1.URL = doublyLinkedList.Current.FilePath;
                    //  textBox1.Text = doublyLinkedList.Current.FileName;
                    // Tìm chỉ số của bài hát hiện tại trong danh sách
                    int currentIndex = 0;
                    var currentNode = doublyLinkedList.Head;

                    while (currentNode != null)
                    {
                        if (currentNode == doublyLinkedList.Current)
                            break;

                        currentNode = currentNode.Next;
                        currentIndex++;
                    }

                    // Cập nhật mục được chọn trên ListBox
                    listBox1.SelectedIndices.Clear();
                    listBox1.SelectedIndex = currentIndex;
                }
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}

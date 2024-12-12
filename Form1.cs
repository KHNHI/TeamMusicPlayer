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
        private DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
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
            if (doublyLinkedList.Current != null)
            {
                doublyLinkedList.MovePrevious();
                if (doublyLinkedList.Current == null)
                {
                    doublyLinkedList.Current = doublyLinkedList.Tail;
                }
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

        private bool isButtonClick = false; // Cờ xác định thay đổi do nút nhấn
        private void btnPlay_Click(object sender, EventArgs e)
        {
            isButtonClick = true; // Đánh dấu trạng thái được thay đổi bởi nút nhấn


            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Tạm dừng nhạc và đổi biểu tượng sang Play
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btnPlay.BackgroundImage = Properties.Resources.playIcon;
                //timer.Stop();
            }
            else
            {
                // Phát nhạc và đổi biểu tượng sang Pause
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btnPlay.BackgroundImage = Properties.Resources.pauseIcon;
                //timer.Start();
            }
            btnPlay.Refresh(); // Cập nhật giao diện
            isButtonClick = false; // Hoàn thành xử lý nút nhấn
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtbSong.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SongNode result = doublyLinkedList.Search(keyword);

            if (result != null)
            {
                // Nếu tìm thấy bài hát, chọn trong ListBox và hiển thị thông tin
                int index = listBox1.Items.IndexOf(result.FileName); // Lấy chỉ số bài hát trong ListBox
                listBox1.SelectedIndex = index; // Chọn bài hát
                MessageBox.Show($"Đã tìm thấy bài hát: {result.FileName}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy bài hát nào phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Processor
{
    /// <summary>
    /// Interaction logic for CommentsToProcess.xaml
    /// </summary>
    public partial class CommentsForProcess : Window
    {
        private int _id;
        private readonly string _path = "comments.csv";

        public List<Comment> CommentsToDisplay { get; set; } = new List<Comment>();
        public CommentsForProcess(Process process)
        {
            InitializeComponent();
            _id = process.Id;
            ReadComments();
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = File.AppendText(_path))
            {
                writer.WriteLine($"{_id},{NewComment.Text}");
            }
            ReadComments();
            NewComment.Clear();
        }

        private void ReadComments()
        {
            CommentListBox.Items.Clear();
            using (var reader = new StreamReader(_path)) 
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] commentData = line.Split(',');
                    if (commentData.Length > 0 && commentData[0] == _id.ToString())
                    {
                        CommentListBox.Items.Add(new ListBoxItem().DataContext = string.Join(", ", commentData.Skip(1)));
                    }
                }
            }
        }
    }
}

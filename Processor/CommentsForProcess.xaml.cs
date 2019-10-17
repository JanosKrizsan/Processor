using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            CreateCsvFile();
            ReadComments();
        }

        private void CreateCsvFile()
        {
            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, string.Empty);
            }
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            AddNewCommentToProcess();
        }

        private void AddNewCommentToProcess()
        {
            var commentText = NewComment.Text.Trim();
            commentText = Regex.Replace(commentText, @"\s+", " ", RegexOptions.Multiline);

            using (StreamWriter writer = File.AppendText(_path))
            {
                writer.WriteLine($"{_id},{commentText}");
            }

            ReadComments();
            NewComment.Clear();
        }
        private void Clear_Comments(object sender, RoutedEventArgs e)
        {
            var lineList = new List<string>();

            using (var reader = new StreamReader(_path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!line.Contains(_id.ToString()))
                    {
                        lineList.Add(line);
                    }
                }
            }

            File.WriteAllText(_path, string.Empty);
            File.AppendAllLines(_path, lineList);

            ReadComments();
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

        private void NewComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddNewCommentToProcess();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Article
    {

        public bool Edit(List<string> cmdFrom1, string[] content, string cmd)
        {
            if (cmd == "Edit:")
            {
                for (int i = 0; i < cmdFrom1.Count; i++)
                {
                    if (cmdFrom1[i] != Content[i]) return true;
                }
            }
            else if (cmd == "ChangeAuthor:")
            {
                for (int i = 0; i < cmdFrom1.Count; i++)
                {
                    if (cmdFrom1[i] != Author[i]) return true;
                }
            }
            else if (cmd == "Rename:")
            {
                for (int i = 0; i < cmdFrom1.Count; i++)
                {
                    if (cmdFrom1[i] != Title[i]) return true;
                }
            }
            return false;
        }



        public string[] Title { get; set; }
        public string[] Content { get; set; }
        public string[] Author { get; set; }

        public Article(string[] title, string[] content, string[] author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] articleFormat = Console.ReadLine().Split(", ").ToArray();
            int commandCount = int.Parse(Console.ReadLine());

            string[] title = articleFormat[0].Split();
            string[] content = articleFormat[1].Split();
            string[] author = articleFormat[2].Split();

            Article info = new Article(title, content, author);

            List<string> cmdFrom1 = new List<string>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                string cmd = command[0];

                for (int j = 1; j < command.Length; j++)
                {
                    cmdFrom1.Add(command[j]);
                }

                if (info.Edit(cmdFrom1, content, cmd))
                {
                    if (cmd == "Edit:")
                    {
                        info.Content = cmdFrom1.ToArray();
                    }
                    else if (cmd == "ChangeAuthor:")
                    {
                        info.Author = cmdFrom1.ToArray();
                    }
                    else if (cmd == "Rename:")
                    {
                        info.Title = cmdFrom1.ToArray();
                    }
                }

                cmdFrom1 = new List<string>();
            }

            Console.WriteLine($"{string.Join(" ", info.Title)} - {string.Join(" ", info.Content)}: {string.Join(" ", info.Author)}");
        }
    }
}

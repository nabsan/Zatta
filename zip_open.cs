     static void Main(string[] args)
        {
            Console.WriteLine("STT");
            // ZIP書庫を開く
            using (ZipArchive a = ZipFile.OpenRead(@"C:\manabu\temp\zip_sample\1.zip"))
            {
                //「1.txt」のZipArchiveEntryを取得する
                ZipArchiveEntry e = a.GetEntry(@"2.txt");
                if (e == null)
                {
                    //見つからなかった時
                    Console.WriteLine("2.txt が見つかりませんでした。");
                }
                else
                {
                    string random = Guid.NewGuid().ToString("N").Substring(0, 12);
                    using (StreamReader sr = new StreamReader(e.Open(),System.Text.Encoding.GetEncoding("shift_jis")))
                    {
                        using (StreamWriter writer = new StreamWriter(@"C:\hoge\temp\hoge.txt", false , System.Text.Encoding.UTF8))
                        {
                            //すべて読み込む
                            //string s = sr.ReadToEnd(); //#このReadToEndはメモリOutOfMemoryが起きがち。utf-8の大きいファイルだと。
                            //Console.Write(s);
                            
                            //案１
                            while (sr.Peek() > -1)
                            {
                                string m = sr.ReadLine();
             
                                Console.WriteLine("dbg=" + m);
                                writer.WriteLine(m);
                            }
                        }
                        
                    }
                    //案２（特定のファイルを解凍するだけなら、こっちがベター）
                    e.ExtractToFile(Path.Combine(@"C:\hoge\temp\", e.FullName+"_"+random+".txt"));
                }

            }
            Console.WriteLine("END");

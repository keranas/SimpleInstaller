using System;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO.Compression;

namespace ApplInstaller
{
    public partial class Form1 : Form
    {
        String path, path1, fileName, icon, texttext, license1, owner;

        public Form1()
        {
            InitializeComponent();
            if (System.IO.File.Exists(@"Install.ini") == true) //read Title and store in Title[500]
            {
                //Read the file line by line.  
                System.IO.StreamReader file1 = new System.IO.StreamReader(@"Install.ini");

                owner = file1.ReadLine();
                texttext = file1.ReadLine();
                Program1.Text = texttext;
                Version1.Text = file1.ReadLine();
                license1= file1.ReadLine();
                textBox.Text = "C:/Program Files/" + owner + "/" + texttext + "/";
                file1.Close();
            }
            else
            {
                MessageBox.Show("Install.ini is missing");
                Application.Exit();
            }


        }

        private void Install_Click(object sender, EventArgs e)
        {


            path1 = @textBox.Text;
            path = @"";
            texttext = Program1.Text;
            fileName = texttext + ".exe";
            icon = @"icon.ico";
            Lsave();
            movefile(path, path1, fileName, icon, texttext,license1);
            moveallfiles(path, path1);
            MessageBox.Show("The Program Installed Succesfully");
            Application.Exit();
        }
        private void Lsave()
        {
            String Temp;
            Temp=textBox.Text;
            String ddd = @Program1.Text;
            String LAname = "                                                                                                                         ";
            LAname = @"C:/" + ddd + "/";
            System.IO.Directory.CreateDirectory(LAname);
            LAname = LAname + "L.txt";
            System.IO.BinaryWriter LIni = new System.IO.BinaryWriter(System.IO.File.Open(LAname, System.IO.FileMode.Create));
            LIni.Write(UTF8Encoding.Default.GetBytes(Temp));
            LIni.Write('\r'); LIni.Write('\n');
            DateTime thisDay = DateTime.Today;
            LIni.Close();

        }
        private void Lread()
        {
            String Temp;
            String W = @Program1.Text;
            if (System.IO.File.Exists(@"C:\\"+W+@"\\L.txt") == true) //read Title and store in Title[500]
            {
                //Read the file line by line.  
                System.IO.StreamReader file2 = new System.IO.StreamReader(@"C:\\" + W + "\\L.txt");


                Temp = file2.ReadLine();
                textBox.Text = Temp;
                file2.Close();
            }
        }
        private void UnInstall_Click(object sender, EventArgs e)
        {
            Lread();

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@textBox.Text);

            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (System.IO.DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }




            String LAname;
            LAname = textBox.Text + "\\" + Program1.Text + ".exe";
            if (System.IO.File.Exists(LAname))
            {
                System.IO.File.Delete(LAname);
            }
            LAname = textBox.Text + "\\" + "icon.ico";
            if (System.IO.File.Exists(LAname))
            {
                System.IO.File.Delete(LAname);
            }
            
            LAname = textBox.Text;
            if (System.IO.Directory.Exists(LAname))
            {
                System.IO.Directory.Delete(LAname);
            }
            LAname = @"C:/" + Program1.Text + "/L.txt";
            if (System.IO.File.Exists(LAname))
            {
                System.IO.File.Delete(LAname);
            }
            LAname = @"C:/" + Program1.Text;
            if (System.IO.Directory.Exists(LAname))
            {
               // System.IO.Directory.Delete(LAname);
            }
            //string WinUser = WindowsIdentity.GetCurrent().Name;
            //WinUser = WinUser.Substring(WinUser.LastIndexOf("\\") + 1);

            string pathD = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (System.IO.File.Exists(pathD +"\\"+ texttext + ".lnk"))
                System.IO.File.Delete(pathD + "\\" + texttext + ".lnk");
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string appStartMenuPath = System.IO.Path.Combine(commonStartMenuPath, "Programs", texttext);
            if (System.IO.File.Exists(appStartMenuPath + "\\"+texttext + ".lnk"))
                System.IO.File.Delete(appStartMenuPath + "\\" + texttext + ".lnk");
            if (System.IO.File.Exists(appStartMenuPath + "\\" + "Uninstall.lnk"))
                System.IO.File.Delete(appStartMenuPath + "\\" + "Uninstall.lnk");
            if (System.IO.Directory.Exists(appStartMenuPath))
                System.IO.Directory.Delete(appStartMenuPath);


            MessageBox.Show("The Program UnInstalled Succesfully");
            Application.Exit();
        }
        private  void movefile(string path, string path2, string fileName, string icon, string texttext, string license1)
        {

            if (!System.IO.Directory.Exists(path2))
            {
                System.IO.Directory.CreateDirectory(@path2);
            }

                try
                {
                String ss = path2 + " \\ "+ fileName;
    
                String so = @path ;
                string sourceFile = System.IO.Path.Combine(path, texttext);
                string sourceIcon= System.IO.Path.Combine(path, icon);
                string destFile = System.IO.Path.Combine(path2, fileName);
                string destIcon = System.IO.Path.Combine(path2, icon);
                //string ssourceFile = System.IO.Path.Combine(path, license1);
                //string ddestFile = System.IO.Path.Combine(path2, license1);
                if (System.IO.File.Exists(destFile))
                    System.IO.File.Delete(destFile);
                if (System.IO.File.Exists(destIcon))
                    System.IO.File.Delete(destIcon);
                //if (System.IO.File.Exists(ddestFile))
                   // System.IO.File.Delete(ddestFile);
                string pathD = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (System.IO.File.Exists(pathD + "\\" + texttext + ".lnk"))
                    System.IO.File.Delete(pathD + "\\" + texttext + ".lnk");
                string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                string appStartMenuPath = System.IO.Path.Combine(commonStartMenuPath, "Programs", texttext);
                if (System.IO.File.Exists(appStartMenuPath + "\\" + texttext + ".lnk"))
                    System.IO.File.Delete(appStartMenuPath + "\\" + texttext + ".lnk");
                // Move the file
                if (System.IO.File.Exists(sourceFile))
                {
                    System.IO.File.Copy(sourceFile, destFile);
                }
                else
                {
                    MessageBox.Show("There is no source file");
                    Application.Exit();
                }

               // if (System.IO.File.Exists(ssourceFile))
               // {
                ////    System.IO.File.Copy(ssourceFile, ddestFile);
               // }
               // else
               // {
               //     System.IO.File.Create(@ddestFile);
               // }


                if (System.IO.File.Exists(sourceIcon))
                {
                    System.IO.File.Copy(sourceFile, destIcon);
                }
                else
                {
                    MessageBox.Show("There is no source file");
                    Application.Exit();
                }

                //commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                //appStartMenuPath = System.IO.Path.Combine(commonStartMenuPath, "Programs", texttext);

                String W = Program1.Text;
                String tempDir = "C:\\" + W;
                String sourceFileInst = "Install.exe";
                String txtemp = "Install.ini";
                String txtempico = "Install.ico";
                String destFileInst = tempDir + "/Uninstall.exe";
                String txtempDest = tempDir + "/Install.ini";
                String txtempicoDest = tempDir + "/Install.ico";
                if (System.IO.Directory.Exists(tempDir) == true) //read Title and store in Title[500]
                {
                    if (System.IO.File.Exists(destFileInst))
                    {
                        System.IO.File.Delete(destFileInst);
                    }
                    if (System.IO.File.Exists(txtempDest))
                    {
                        System.IO.File.Delete(txtempDest);
                    }
                    if (System.IO.File.Exists(txtempicoDest))
                    {
                        System.IO.File.Delete(txtempicoDest);
                    }
                    System.IO.File.Copy(@sourceFileInst, @destFileInst);
                    System.IO.File.Copy(@txtemp, @txtempDest);
                    System.IO.File.Copy(@txtempico, @txtempicoDest);
                }

                string shortcutLocation = System.IO.Path.Combine(@pathD, @texttext + @".lnk");
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                shortcut.Description = texttext;   // The description of the shortcut
                shortcut.IconLocation = @destIcon;           // The icon of the shortcut
                shortcut.TargetPath = @destFile;                 // The path of the file that will launch when the shortcut is run
                shortcut.WorkingDirectory = @path2;
                shortcut.Save();



                if (!System.IO.Directory.Exists(appStartMenuPath))
                {
                    System.IO.Directory.CreateDirectory(appStartMenuPath);
                }
                shortcutLocation = appStartMenuPath + "\\" + texttext + ".lnk";
                WshShell shell1 = new WshShell();
                IWshShortcut shortcut1 = (IWshShortcut)shell1.CreateShortcut(shortcutLocation);
                shortcut1.Description = texttext;   // The description of the shortcut
                shortcut1.IconLocation = @destIcon;           // The icon of the shortcut
                shortcut1.TargetPath = @destFile;                 // The path of the file that will launch when the shortcut is run
                shortcut1.WorkingDirectory = @path2;
                shortcut1.Save();


               String  destIconInst = "Install.ico";
               
                shortcutLocation = appStartMenuPath + "\\" + "Uninstall" + ".lnk";
                WshShell shell2 = new WshShell();
                IWshShortcut shortcut2 = (IWshShortcut)shell2.CreateShortcut(shortcutLocation);
                shortcut2.Description = "Uninstall";   // The description of the shortcut
                shortcut2.IconLocation = @txtempicoDest;           // The icon of the shortcut
                shortcut2.TargetPath = @destFileInst;                 // The path of the file that will launch when the shortcut is run
                shortcut2.WorkingDirectory = @tempDir;
                shortcut2.Save();

            }
            catch (Exception e)
            {
                MessageBox.Show("The process failed");
            }
        }
        //Now Create all of the directories
        private  void moveallfiles(string SourcePath, string DestinationPath)
        {
            SourcePath=System.IO.Directory.GetCurrentDirectory();
            foreach (string dirPath in System.IO.Directory.GetDirectories(SourcePath, "*",
                System.IO.SearchOption.AllDirectories))
                System.IO.Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in System.IO.Directory.GetFiles(SourcePath, "*.*",
                System.IO.SearchOption.AllDirectories))
            {
                
                //check the extention
                string ext = System.IO.Path.GetExtension(newPath);
                if(ext==".zip")
                        {
                    unziptemp(newPath, DestinationPath);
                }
                else
                {
                    System.IO.File.Copy(newPath, newPath.Replace(SourcePath, @DestinationPath), true);
                }
            }
            // Delete the main program without the extention
            string destFile = System.IO.Path.Combine(DestinationPath, Program1.Text);
            System.IO.File.Delete(destFile);
        }
        private void unziptemp(string newPath, string DestinationPath)
        {
            String LAname;
            LAname = @"C:\\1234tzip";
            System.IO.Directory.CreateDirectory(LAname);
            //string startPath = @"c:\example\start";
            // string zipPath = @"c:\example\result.zip";
            //string extractPath = @"c:\example\extract";

            //System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
            System.IO.Compression.ZipFile.ExtractToDirectory(newPath, LAname);
            foreach (string dirPath in System.IO.Directory.GetDirectories(LAname, "*",
                System.IO.SearchOption.AllDirectories))
                System.IO.Directory.CreateDirectory(dirPath.Replace(LAname, DestinationPath));
            foreach (string nPath in System.IO.Directory.GetFiles(LAname, "*.*",
                System.IO.SearchOption.AllDirectories))
            {
                    System.IO.File.Copy(nPath, nPath.Replace(LAname, @DestinationPath), true);
            }

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(LAname);
            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (System.IO.DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            System.IO.Directory.Delete(LAname);
        }
    }
}

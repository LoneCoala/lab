using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Security;
using System.Text;

namespace Virt_lab_25
{
    public partial class Protocol : Form
    {
        DateTime currentDate = DateTime.Now;
        
        string key = "b22ca5898a4e4133bbce2ea2322a1916";
        string[] encryptedString = new string[5];
        
        string decryptedString = "";
        public string fullName = "";
        public string groupName = "";
        public int countErrors = 0;
        public string workName = "Лаб. Работа №25";
        
        public string fullnameDecrypted = "";
        public string groupNameDecrypted = "";
        public string countErrorsDecrypted = "";
        public string workNameDecrypted = "";
        public string currentDateDecrypted = "";
        
        public Protocol()
        {
            InitializeComponent();
            MaximizeBox = false;

        }

        private void Protocol_Load(object sender, EventArgs e)
        {
                if (countErrors == 0)
                {
                    label1.Text = "Время выполнения работы: " + currentDate + "\n" + workName + "\nФИО:  " + fullName + "\nГруппа: " + groupName + "\nЛабораторная работа выполнена успешно." + "\nКоличество ошибок: " + countErrors.ToString();
                }
                else
                {
                    label1.Text = "Время выполнения работы: " + currentDate + "\n" + workName + "\nФИО:  " + fullName + "\nГруппа: " + groupName + "\nЛабораторная работа выполнена с ошибками." + "\nКоличество ошибок: " + countErrors.ToString();
                }

            
        }

        private void exportProtocol_Click(object sender, EventArgs e)
        {
            var str = label1.Text;
            var encryptedString = AesOperation.EncryptString(key, str);

            var nameEncrypted = AesOperation.EncryptString(key, fullName);
            var groupNameEncrypted = AesOperation.EncryptString(key, groupName);
            var countErrorsEncrypted = AesOperation.EncryptString(key, countErrors.ToString());
            var workNameEncrypted = AesOperation.EncryptString(key, workName);
            var currentDateEncrypted = AesOperation.EncryptString(key, currentDate.ToString());

            string[] encryptedStrings = new string[] { nameEncrypted, groupNameEncrypted, countErrorsEncrypted, workNameEncrypted, currentDateEncrypted };

            this.encryptedString = encryptedStrings;

            //System.IO.File.WriteAllText("protocol.prot", encryptedStrings);
            File.WriteAllLines(fullName + "_Лаб25_ " + groupName  + ".prot", encryptedStrings);

            MessageBox.Show("Протокол выгружен в папку с программой");
        }

        private void importProtocol_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    if (Path.GetExtension(openFileDialog1.FileName) == ".prot")
                    {
                        var list = new List<string>();
                        while(!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            list.Add(line);
                        }
                        
                        var arrTheoria = list.ToArray();

                        this.fullnameDecrypted = AesOperation.DecryptString(key, arrTheoria[0]);
                        this.groupNameDecrypted = AesOperation.DecryptString(key, arrTheoria[1]);
                        this.countErrorsDecrypted = AesOperation.DecryptString(key, arrTheoria[2]);
                        this.workNameDecrypted = AesOperation.DecryptString(key, arrTheoria[3]);
                        this.currentDateDecrypted = AesOperation.DecryptString(key, arrTheoria[4]);
                        
                        MessageBox.Show("Протокол загружен");
                    } else
                    {
                        MessageBox.Show("Не поддерживаемый файл");
                        return;
                    }
                    
                    sr.Close();
                    
                    if (Convert.ToInt32(this.countErrorsDecrypted) == 0)
                    {
                        label1.Text = "Время выполнения работы: " + this.currentDateDecrypted + "\n" + this.workNameDecrypted + "\nФИО:  " + this.fullnameDecrypted +"\nГруппа: " + this.groupNameDecrypted + "\nЛабораторная работа выполнена успешно." + "\nКоличество ошибок: " + this.countErrorsDecrypted;
                    }
                    else
                    {
                        label1.Text = "Время выполнения работы: " + this.currentDateDecrypted + "\n" + this.workNameDecrypted + "\nФИО:  " + this.fullnameDecrypted +"\nГруппа: " + this.groupNameDecrypted + "\nЛабораторная работа выполнена с ошибками." + "\nКоличество ошибок: " + this.countErrorsDecrypted;
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show("Чет не то");
                }
            }
            //var decryptedString = AesOperation.DecryptString(key, File.ReadAllText("protocol.prot"));

           
            
        }
    }
    
    public class AesOperation
    {
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
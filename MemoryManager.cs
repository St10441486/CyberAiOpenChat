﻿using System;
using System.Collections.Generic;
using System.IO;

namespace CyberAiOpenChat
{
    public class MemoryManager
    {
        private string GetFilePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string rootPath = baseDir.Replace("bin\\Debug\\", "");
            return Path.Combine(rootPath, "chat_history.txt");
        }

        public void EnsureFileExists()
        {
            string path = GetFilePath();
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void SaveConversation(List<string> entries)
        {
            string path = GetFilePath();
            EnsureFileExists();
            File.AppendAllLines(path, entries);
        }

        public List<string> GetHistory()
        {
            string path = GetFilePath();
            EnsureFileExists();
            return new List<string>(File.ReadAllLines(path));
        }

        // ✅ Proper implementation for LoadConversation used in ChatBotMenu
        public IEnumerable<string> LoadConversation()
        {
            return GetHistory();
        }
    }
}

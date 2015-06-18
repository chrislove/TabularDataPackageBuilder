﻿using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabularDataPackage;

namespace TabularDataPackage.Test
{
    /// <summary>
    /// Summary description for UnitTest_Csv
    /// </summary>
    [TestClass]
    public class UnitTest_Csv
    {
        public UnitTest_Csv()
        {

        }

        [TestMethod]
        public void CsvValidSHA1Hash()
        {
            TabularDataPackage.Csv _csv = new TabularDataPackage.Csv();
            string contents = "This is a test file. Please delete me.";
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, contents);
            string hash = _csv.GetSHA1Hash(tempFile);
            File.Delete(tempFile);
            Assert.AreEqual("CC5872242874C1D33B6B41F37279321D6959F34C", hash);
        }

        [TestMethod]
        public void CsvInvalidSHA1Hash()
        {
            TabularDataPackage.Csv _csv = new TabularDataPackage.Csv();
            string contents = "This is a test file. Please delete me.";
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, contents);
            string hash = _csv.GetSHA1Hash(tempFile);
            File.Delete(tempFile);
            Assert.AreNotEqual("NotTheHash", hash);
        }

        [TestMethod]
        public void CsvIsUTF8()
        {
            TabularDataPackage.Csv _csv = new TabularDataPackage.Csv();
            string contents = "This is a test file. Please delete me.";
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, contents, Encoding.UTF8);
            bool isUTF8 = _csv.GetIsUTF8(tempFile);
            File.Delete(tempFile);
            Assert.AreEqual(true, isUTF8);
        }

        [TestMethod]
        public void CsvIsUnicode()
        {
            TabularDataPackage.Csv _csv = new TabularDataPackage.Csv();
            string contents = "This is a test file. Please delete me.";
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, contents, Encoding.Unicode);
            bool isUTF8 = _csv.GetIsUTF8(tempFile);
            File.Delete(tempFile);
            Assert.AreNotEqual(true, isUTF8);
        }
    }
}
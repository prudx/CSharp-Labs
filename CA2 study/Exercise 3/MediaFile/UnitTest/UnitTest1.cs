using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Media;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [Ignore]
        [TestMethod]
        public void TestNoFilenameValidation()
        {
            //should be throwing because no filename
            Assert.ThrowsException<Exception>(() => { MusicFile song = new MusicFile("", "Song 2", "Blur"); });
        }

        [TestMethod]
        public void TestTitlePropertyValidation()
        {
            Assert.ThrowsException<Exception>(() => { MusicFile song = new MusicFile("Song 2.mp3", "", "Blur"); });
        }

        [TestMethod]
        public void TestArtistPropertyValidation()
        {
            Assert.ThrowsException<Exception>(() => { MusicFile song = new MusicFile("Song 2.mp3", "Song 2", ""); });
        }

        
        [TestMethod]
        public void TestGenreDefaultValidation()
        {
            MusicFile song = new MusicFile("Song 2.mp3", "Song 2", "Blur");
            Assert.AreEqual(song.Genre, Genre.Other);
        }

        [TestMethod]
        public void TestAddMethod()
        {
            MusicFile song = new MusicFile("Song 2.mp3", "Song 2", "Blur");
            Playlist p1 = new Playlist("Cool songs");

            p1.AddMusicFile(song);
            
            Assert.IsTrue(p1.Songs.Contains(song));
        }

        [TestMethod]
        public void TestAddMethodDuplicateRestriction()
        {
            MusicFile song = new MusicFile("Song 2.mp3", "Song 2", "Blur");
            Playlist p1 = new Playlist("Cool songs");

            p1.AddMusicFile(song);

            Assert.ThrowsException<Exception>(() => { p1.AddMusicFile(song); });
        }

    }
}

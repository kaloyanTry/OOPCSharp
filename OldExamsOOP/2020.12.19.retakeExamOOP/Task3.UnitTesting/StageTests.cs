// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities; //comment for Judge
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
	using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private List<Song> songs;
		private List<Performer> performers;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
			songs = new List<Song>();
			performers = new List<Performer>();
        }

		[Test]
		public void Ctor_ShouldBeValidStage()
        {
			Assert.IsNotNull(stage);
        }
		[Test]
		public void Ctor_ShouldBeValidSongs()
		{
			Assert.IsNotNull(songs);
		}
		[Test]
		public void Ctor_ShouldBeValidPerformer()
		{
			Assert.IsNotNull(performers);
		}

		[Test]
		public void AddPerformer_ShouldAddCorrectly()
		{
			var performer = new Performer("Fil", "Kir", 25);
			performers.Add(performer);
			Assert.That(performers.Contains(performer));
		}

		[Test]
	    public void AddPerformerStage_ShouldThrowException_WhenUnder18()
	    {
			var performer = new Performer("Fil", "Kir", 2);

			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));
		}

		[Test]
		public void AddSong_Correctly()
        {
			var song = new Song("You", new TimeSpan(0, 3, 24));
			songs.Add(song);

			Assert.That(songs.Contains(song));
        }

		[Test]
		public void AddSongStage_ShouldThrowException_WhenUnder1()
		{
			var song = new Song("You", new TimeSpan(0, 0, 24));

			Assert.That(() => stage.AddSong(song), Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
		}

		[Test]
		public void AddSongTOPerformer_ShouldWorkCorrectly()
        {
			var song = new Song("You", new TimeSpan(0, 2, 24));
			var performer = new Performer("Fil", "Kir", 29);

			performer.SongList.Add(song);

			Assert.That(performer.SongList.Contains(song));
		}

		[Test]
		public void AddSongToPerformer_ShouldThrowExcetion()
		{
			var song = new Song("You", new TimeSpan(0, 2, 24));
			var performer = new Performer("Fil", "Kir", 29);
			performer.SongList.Add(song);

			Assert.That(performer.SongList.Contains(song));
		}

		[Test]
		public void GetPerformer_ShouldCountCorrectlyPerformer()
		{
			var performer = new Performer("Fil", "Kir", 29);
			stage.AddPerformer(performer);

			Assert.That(stage.Performers.Count, Is.EqualTo(1));
		}

		public void GetPErformer_ShouldReturn()
		{
			Assert.Throws<ArgumentException>(() => performers.Contains(new Performer("Aa", "Ka", 144)), "There is no performer with this name."); 
		}

		[Test]
		public void AddSongToPerformer_ShouldCountCorrectly()
		{
			var song = new Song("You", new TimeSpan(0, 2, 24));
			var performer = new Performer("Fil", "Kir", 29);
			performer.SongList.Add(song);

			Assert.That(performer.SongList.Count, Is.EqualTo(1));
		}

		[Test]
		public void Play_ShouldCountCorrectlyPerformer()
        {
			var performer = new Performer("Fil", "Kir", 29);
			performers.Add(performer);

			Assert.That(performers.Count, Is.EqualTo(1));
		}

		[Test]
		public void ValidateNullSong_ShouldThrowException()
        {
			Assert.That(() => stage.AddSong(null), Throws.ArgumentNullException);
        }


		[Test]
		public void ValidateNullPerformer_ShouldThrowException()
		{
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}
	}
}
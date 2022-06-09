using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Medicaments { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }

        protected MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(p =>
            {
                p.HasKey(e => e.idMusician);
                p.Property(e => e.firstName).IsRequired().HasMaxLength(30);
                p.Property(e => e.lastName).IsRequired().HasMaxLength(50);
                p.Property(e => e.nickName).HasMaxLength(20);

                p.HasData(
                    new Musician() { idMusician = 1, firstName = "Andrzej", lastName = "Lisenkov", nickName = "Monster1"},
                    new Musician() { idMusician = 2, firstName = "Ryszard", lastName = "Warzocha", nickName = "Monster2"},
                    new Musician() { idMusician = 3, firstName = "Konrad", lastName = "Wal", nickName = "Monster3" });
            });

            modelBuilder.Entity<MusicLabel>(p =>
            {
                p.HasKey(e => e.idMusicLabel);
                p.Property(e => e.name).IsRequired().HasMaxLength(50);

                p.HasData(
                    new MusicLabel() { idMusicLabel = 1, name = "Label 1"},
                    new MusicLabel() { idMusicLabel = 2, name = "Label 2" },
                    new MusicLabel() { idMusicLabel = 3, name = "Label 3" });
            });

            modelBuilder.Entity<Album>(p =>
            {
                p.HasKey(e => e.idAlbum);
                p.Property(e => e.albumName).IsRequired().HasMaxLength(30);
                p.Property(e => e.publishDate).IsRequired();

                p.HasOne(e => e.musicLabel).WithMany(e => e.albums).HasForeignKey(e => e.idMusicLabel);

                p.HasData(
                    new Album() { idAlbum = 1, albumName = "Album 1", publishDate = DateTime.Parse("2011-04-01"), idMusicLabel = 1 },
                    new Album() { idAlbum = 2, albumName = "Album 2", publishDate = DateTime.Parse("2011-05-01"), idMusicLabel = 2 },
                   new Album() { idAlbum = 3, albumName = "Album 3", publishDate = DateTime.Parse("2011-06-01"), idMusicLabel = 3 });
            });

            modelBuilder.Entity<Track>(p =>
            {
                p.HasKey(e => e.idTrack);
                p.Property(e => e.trackName).IsRequired().HasMaxLength(20);
                p.Property(e => e.duration).IsRequired();

                p.HasOne(e => e.album).WithMany(e => e.tracks).HasForeignKey(e => e.idMusicAlbum);

                p.HasData(
                   new Track() { idTrack = 1, trackName = "track 1", duration = 5, idMusicAlbum = 1 },
                   new Track() { idTrack = 2, trackName = "track 2", duration = 6, idMusicAlbum = 2 },
                   new Track() { idTrack = 3, trackName = "track 3", duration = 7, idMusicAlbum = 3 });
            });

            modelBuilder.Entity<Musician_Track>(p =>
            {
                p.HasKey(e => new { e.idMusician, e.idTrack });

                p.HasOne(e => e.musician).WithMany(e => e.musician_Tracks).HasForeignKey(e => e.idMusician);
                p.HasOne(e => e.track).WithMany(e => e.musician_Tracks).HasForeignKey(e => e.idTrack);

                p.HasData(
                   new Musician_Track() { idTrack = 1, idMusician = 1 },
                   new Musician_Track() { idTrack = 2, idMusician = 2 },
                   new Musician_Track() { idTrack = 3, idMusician = 3 });
            });
        }

    }
}

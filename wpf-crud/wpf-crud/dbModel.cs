namespace wpf_crud
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbModel : DbContext
    {
        public dbModel()
            : base("name=hw2db")
        {
        }

        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<pub_info> pub_info { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<titleauthor> titleauthors { get; set; }
        public virtual DbSet<title> titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<author>()
                .Property(e => e.au_id)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.au_lname)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.au_fname)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .Property(e => e.zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<author>()
                .HasMany(e => e.titleauthors)
                .WithRequired(e => e.author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pub_info>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<pub_info>()
                .Property(e => e.pr_info)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.pub_name)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.state)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .HasOptional(e => e.pub_info)
                .WithRequired(e => e.publisher);

            modelBuilder.Entity<titleauthor>()
                .Property(e => e.au_id)
                .IsUnicode(false);

            modelBuilder.Entity<titleauthor>()
                .Property(e => e.title_id)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.title_id)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.title1)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<title>()
                .Property(e => e.advance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<title>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<title>()
                .HasMany(e => e.titleauthors)
                .WithRequired(e => e.title)
                .WillCascadeOnDelete(false);
        }
    }
}

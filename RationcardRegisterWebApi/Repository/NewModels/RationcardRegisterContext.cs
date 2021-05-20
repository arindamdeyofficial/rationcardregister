using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.NewModels
{
    public partial class RationcardRegisterContext : DbContext
    {
        public RationcardRegisterContext()
        {
        }

        public RationcardRegisterContext(DbContextOptions<RationcardRegisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppStartHi> AppStartHis { get; set; }
        public virtual DbSet<LoginHi> LoginHis { get; set; }
        public virtual DbSet<MstCat> MstCats { get; set; }
        public virtual DbSet<MstCustomer> MstCustomers { get; set; }
        public virtual DbSet<MstDist> MstDists { get; set; }
        public virtual DbSet<MstRel> MstRels { get; set; }
        public virtual DbSet<MstRole> MstRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ARINDAMGONOKJAN\\SQL2019;Database=RationcardRegister;User Id=sa;Password=Nakshal!01051987;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppStartHi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("App_Start_His");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.GatewayAddr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Gateway_Addr");

                entity.Property(e => e.InternalIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Internal_Ip");

                entity.Property(e => e.PublicIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Public_Ip");
            });

            modelBuilder.Entity<LoginHi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Login_His");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.DistLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Login");

                entity.Property(e => e.LoginSuccess).HasColumnName("Login_Success");
            });

            modelBuilder.Entity<MstCat>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Mst_Cat__26E35140055FECEE");

                entity.ToTable("Mst_Cat");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CatDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cat_Desc");
            });

            modelBuilder.Entity<MstCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerRowId)
                    .HasName("PK__Mst_Cust__3CA18CF1D74485BA");

                entity.ToTable("Mst_Customer");

                entity.Property(e => e.CustomerRowId).HasColumnName("Customer_Row_Id");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.AdharNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adhar_No");

                entity.Property(e => e.CardCategoryId).HasColumnName("Card_Category_Id");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CustomerSerial).HasColumnName("Customer_Serial");

                entity.Property(e => e.FamilyId).HasColumnName("Family_Id");

                entity.Property(e => e.GaurdianName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Gaurdian_Name");

                entity.Property(e => e.GaurdianRelId).HasColumnName("Gaurdian_Rel_Id");

                entity.Property(e => e.HofId).HasColumnName("Hof_Id");

                entity.Property(e => e.InactivatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inactivated_Date");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_No");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RelationWithHofId).HasColumnName("Relation_With_Hof_Id");
            });

            modelBuilder.Entity<MstDist>(entity =>
            {
                entity.HasKey(e => e.DistId)
                    .HasName("PK__Mst_Dist__527E9561B6239064");

                entity.ToTable("Mst_Dist");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistAddress)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Address");

                entity.Property(e => e.DistEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Email");

                entity.Property(e => e.DistFpsCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Fps_Code");

                entity.Property(e => e.DistFpsLiscenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Fps_Liscence_No");

                entity.Property(e => e.DistGoogleMapLocation)
                    .IsUnicode(false)
                    .HasColumnName("Dist_GoogleMapLocation");

                entity.Property(e => e.DistLocked).HasColumnName("Dist_Locked");

                entity.Property(e => e.DistLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Login");

                entity.Property(e => e.DistMobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Mobile_No");

                entity.Property(e => e.DistMrShopNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Mr_Shop_No");

                entity.Property(e => e.DistName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Name");

                entity.Property(e => e.EmailToNotify)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNoToNotifyViaSms)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstRel>(entity =>
            {
                entity.ToTable("Mst_Rel");

                entity.Property(e => e.MstRelId).HasColumnName("Mst_Rel_Id");

                entity.Property(e => e.Relation)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Mst_Role__D80AB4BBAF150D26");

                entity.ToTable("Mst_Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.ControlIdToHide)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role_Desc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

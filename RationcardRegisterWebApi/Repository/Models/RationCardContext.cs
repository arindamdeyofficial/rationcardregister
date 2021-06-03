using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Models
{
    public partial class RationCardContext : DbContext
    {
        public RationCardContext(DbContextOptions<RationCardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AgentInstance> AgentInstances { get; set; }
        public virtual DbSet<AgentVersion> AgentVersions { get; set; }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
        public virtual DbSet<AppStartHi> AppStartHis { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<BillCounter> BillCounters { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<BillInput> BillInputs { get; set; }
        public virtual DbSet<BillMaster> BillMasters { get; set; }
        public virtual DbSet<CardSearchInput> CardSearchInputs { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EnumType> EnumTypes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }
        public virtual DbSet<LoginHi> LoginHis { get; set; }
        public virtual DbSet<MacList> MacLists { get; set; }
        public virtual DbSet<MessageQueue> MessageQueues { get; set; }
        public virtual DbSet<MetaInformation> MetaInformations { get; set; }
        public virtual DbSet<MetaInformation1> MetaInformations1 { get; set; }
        public virtual DbSet<MstCat> MstCats { get; set; }
        public virtual DbSet<MstCustomer> MstCustomers { get; set; }
        public virtual DbSet<MstDist> MstDists { get; set; }
        public virtual DbSet<MstDoc> MstDocs { get; set; }
        public virtual DbSet<MstDocType> MstDocTypes { get; set; }
        public virtual DbSet<MstRel> MstRels { get; set; }
        public virtual DbSet<MstRole> MstRoles { get; set; }
        public virtual DbSet<MstSearchCat> MstSearchCats { get; set; }
        public virtual DbSet<ProductBrandMaster> ProductBrandMasters { get; set; }
        public virtual DbSet<ProductClassMaster> ProductClassMasters { get; set; }
        public virtual DbSet<ProductDeptMaster> ProductDeptMasters { get; set; }
        public virtual DbSet<ProductInput> ProductInputs { get; set; }
        public virtual DbSet<ProductMaster> ProductMasters { get; set; }
        public virtual DbSet<ProductMcMaster> ProductMcMasters { get; set; }
        public virtual DbSet<ProductPerCustomer> ProductPerCustomers { get; set; }
        public virtual DbSet<ProductQuantityMaster> ProductQuantityMasters { get; set; }
        public virtual DbSet<ProductRate> ProductRates { get; set; }
        public virtual DbSet<ProductSearchInput> ProductSearchInputs { get; set; }
        public virtual DbSet<ProductStock> ProductStocks { get; set; }
        public virtual DbSet<ProductStockHi> ProductStockHis { get; set; }
        public virtual DbSet<ProductStockReport> ProductStockReports { get; set; }
        public virtual DbSet<ProductStockReportInput> ProductStockReportInputs { get; set; }
        public virtual DbSet<ProductSubClassMaster> ProductSubClassMasters { get; set; }
        public virtual DbSet<ProductSubDeptMaster> ProductSubDeptMasters { get; set; }
        public virtual DbSet<ProductUom> ProductUoms { get; set; }
        public virtual DbSet<Scaleunitlimit> Scaleunitlimits { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleTask> ScheduleTasks { get; set; }
        public virtual DbSet<ScheduleTask1> ScheduleTasks1 { get; set; }
        public virtual DbSet<SecurityCode> SecurityCodes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SyncObjectDatum> SyncObjectData { get; set; }
        public virtual DbSet<Syncgroup> Syncgroups { get; set; }
        public virtual DbSet<Syncgroupmember> Syncgroupmembers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Taskdependency> Taskdependencies { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TxnCardInputDatum> TxnCardInputData { get; set; }
        public virtual DbSet<TxnRationCard> TxnRationCards { get; set; }
        public virtual DbSet<Uihistory> Uihistories { get; set; }
        public virtual DbSet<Uom> Uoms { get; set; }
        public virtual DbSet<Userdatabase> Userdatabases { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                //optionsBuilder.UseSqlServer("Server=tcp:biplabhomesqldbs.database.windows.net,1433;Initial Catalog=RationCard;Persist Security Info=False;User ID=biplabhomeSql;Password=Nakshal!01051987;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("action", "dss");

                entity.HasIndex(e => new { e.State, e.Lastupdatetime }, "index_action_state_lastupdatetime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Creationtime)
                    .HasColumnType("datetime")
                    .HasColumnName("creationtime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Lastupdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdatetime");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Syncgroupid).HasColumnName("syncgroupid");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("agent", "dss");

                entity.HasIndex(e => new { e.Subscriptionid, e.Name }, "IX_Agent_SubId_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsOnPremise).HasColumnName("is_on_premise");

                entity.Property(e => e.Lastalivetime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastalivetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(140)
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(256)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(256)
                    .HasColumnName("password_salt");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

                entity.Property(e => e.Version)
                    .HasMaxLength(40)
                    .HasColumnName("version");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.Subscriptionid)
                    .HasConstraintName("FK__agent__subscript");
            });

            modelBuilder.Entity<AgentInstance>(entity =>
            {
                entity.ToTable("agent_instance", "dss");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.Lastalivetime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastalivetime");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("version");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.AgentInstances)
                    .HasForeignKey(d => d.Agentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__agent_ins__agent");
            });

            modelBuilder.Entity<AgentVersion>(entity =>
            {
                entity.ToTable("agent_version", "dss");

                entity.HasIndex(e => e.Version, "UQ__agent_ve__0F5401345A5B9BF8")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.ExpiresOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('9999-12-31 23:59:59.997')");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.HasKey(e => e.AppConfigIdentity)
                    .HasName("PK__App_Conf__5C05AFCCD6D31DEC");

                entity.ToTable("App_Config");

                entity.Property(e => e.AppConfigIdentity).HasColumnName("App_Config_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.KeyText)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_Date");

                entity.Property(e => e.ValueText)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppStartHi>(entity =>
            {
                entity.HasKey(e => e.AppStartHisId)
                    .HasName("PK__App_Star__A96430E3AC14ABF2");

                entity.ToTable("App_Start_His");

                entity.Property(e => e.AppStartHisId).HasColumnName("App_Start_His_Id");

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

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.MacId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mac_Id");

                entity.Property(e => e.PublicIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Public_Ip");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Batch");

                entity.Property(e => e.BatchId)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.BatchTeacherId)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BillCounter>(entity =>
            {
                entity.HasKey(e => e.BillCounterIdentity)
                    .HasName("PK__Bill_Cou__6CAC965CDA8A0EC2");

                entity.ToTable("Bill_Counter");

                entity.Property(e => e.BillCounterIdentity).HasColumnName("Bill_Counter_Identity");

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => e.BillDetailsIdIdentity)
                    .HasName("PK__Bill_Det__313E521F1E14B027");

                entity.ToTable("Bill_Details");

                entity.Property(e => e.BillDetailsIdIdentity).HasColumnName("Bill_Details_Id_Identity");

                entity.Property(e => e.ArticleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Article_Code");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUomId).HasColumnName("Base_UOM_Id");

                entity.Property(e => e.BillId).HasColumnName("Bill_Id");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProdDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.ProductBrand)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Brand");

                entity.Property(e => e.ProductBuyingRate)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Product_Buying_Rate");

                entity.Property(e => e.ProductClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Class");

                entity.Property(e => e.ProductDept)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Dept");

                entity.Property(e => e.ProductMc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_MC");

                entity.Property(e => e.ProductMrpRate)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Product_Mrp_Rate");

                entity.Property(e => e.ProductSellingRate)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Product_Selling_Rate");

                entity.Property(e => e.ProductStock)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Product_Stock");

                entity.Property(e => e.ProductSubClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_SubClass");

                entity.Property(e => e.ProductSubDept)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_SubDept");

                entity.Property(e => e.Quantity).HasColumnType("decimal(15, 0)");

                entity.Property(e => e.QuantityUomId).HasColumnName("QuantityUOM_Id");

                entity.Property(e => e.Uomtype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UOMType");
            });

            modelBuilder.Entity<BillInput>(entity =>
            {
                entity.HasKey(e => e.BillInputtIdentity)
                    .HasName("PK__Bill_Inp__AD215BFFF43103B5");

                entity.ToTable("Bill_Input");

                entity.Property(e => e.BillInputtIdentity).HasColumnName("Bill_Inputt_Identity");

                entity.Property(e => e.BillXml)
                    .HasColumnType("xml")
                    .HasColumnName("Bill_Xml");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");
            });

            modelBuilder.Entity<BillMaster>(entity =>
            {
                entity.HasKey(e => e.BillIdIdentity)
                    .HasName("PK__Bill_Mas__281F9FB297465187");

                entity.ToTable("Bill_Master");

                entity.Property(e => e.BillIdIdentity).HasColumnName("Bill_Id_Identity");

                entity.Property(e => e.BalanceAmount).HasColumnType("decimal(15, 0)");

                entity.Property(e => e.BillAmount).HasColumnType("decimal(15, 0)");

                entity.Property(e => e.BillAmountRoundedOff).HasColumnType("decimal(15, 0)");

                entity.Property(e => e.BillNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BillSerialNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Discount).HasColumnType("decimal(15, 0)");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(15, 0)");

                entity.Property(e => e.PrdDefaultQuantitySummary)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RationcardNumbers)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CardSearchInput>(entity =>
            {
                entity.HasKey(e => e.CardSearchInputIdentity)
                    .HasName("PK__Card_Sea__CB124D90329E9CC3");

                entity.ToTable("Card_Search_Input");

                entity.Property(e => e.CardSearchInputIdentity).HasColumnName("Card_Search_Input_Identity");

                entity.Property(e => e.CatId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.DtFrom)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Dto)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DTo");

                entity.Property(e => e.SearchBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SearchText)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("configuration", "dss");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ConfigKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ConfigValue)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Course");

                entity.Property(e => e.CourseDesc).HasMaxLength(1000);

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.CourseName).HasMaxLength(500);
            });

            modelBuilder.Entity<EnumType>(entity =>
            {
                entity.ToTable("EnumType", "dss");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "TaskHosting");

                entity.HasIndex(e => e.IsCancelled, "index_job_iscancelled");

                entity.Property(e => e.JobId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InitialInsertTimeUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("InitialInsertTimeUTC")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Logger>(entity =>
            {
                entity.HasKey(e => e.LoggerIdentity)
                    .HasName("PK__Logger__06BE87A164C3EFB3");

                entity.ToTable("Logger");

                entity.Property(e => e.LoggerIdentity).HasColumnName("Logger_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LogText).IsUnicode(false);

                entity.Property(e => e.MacId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mac_Id");
            });

            modelBuilder.Entity<LoginHi>(entity =>
            {
                entity.HasKey(e => e.LoginHisId)
                    .HasName("PK__Login_Hi__881BA83AC9DC1EA6");

                entity.ToTable("Login_His");

                entity.Property(e => e.LoginHisId).HasColumnName("Login_His_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Login");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.LoginSuccess).HasColumnName("Login_Success");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Login_Time");

                entity.Property(e => e.MacId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mac_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<MacList>(entity =>
            {
                entity.HasKey(e => e.MacIdIdentity)
                    .HasName("PK__Mac_List__02FFAF013EEC5AC7");

                entity.ToTable("Mac_List");

                entity.Property(e => e.MacIdIdentity).HasColumnName("Mac_Id_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.MacId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mac_Id");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MessageQueue>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__MessageQ__C87C0C9CD0259A40");

                entity.ToTable("MessageQueue", "TaskHosting");

                entity.HasIndex(e => new { e.QueueId, e.UpdateTimeUtc, e.InsertTimeUtc, e.ExecTimes, e.Version }, "index_messagequeue_getnextmessage");

                entity.HasIndex(e => new { e.QueueId, e.MessageType, e.UpdateTimeUtc, e.InsertTimeUtc, e.ExecTimes, e.Version }, "index_messagequeue_getnextmessagebytype");

                entity.HasIndex(e => e.JobId, "index_messagequeue_jobid");

                entity.Property(e => e.MessageId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InitialInsertTimeUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("InitialInsertTimeUTC")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.InsertTimeUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("InsertTimeUTC");

                entity.Property(e => e.UpdateTimeUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("UpdateTimeUTC");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.MessageQueues)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__MessageQu__JobId__3B818FAF");
            });

            modelBuilder.Entity<MetaInformation>(entity =>
            {
                entity.ToTable("MetaInformation", "dss");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.VersionString)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1.0.0.0')");
            });

            modelBuilder.Entity<MetaInformation1>(entity =>
            {
                entity.ToTable("MetaInformation", "TaskHosting");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.VersionString)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1.0.0.0')");
            });

            modelBuilder.Entity<MstCat>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Mst_Cat__26E351409D9D9A3E");

                entity.ToTable("Mst_Cat");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CatDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cat_Desc");

                entity.Property(e => e.CatKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cat_Key");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<MstCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Mst_Cust__8CB28699B7525839");

                entity.ToTable("Mst_Customer");

                entity.HasIndex(e => new { e.DistId, e.AdharNo }, "nci_wi_Mst_Customer_0D37B701020FB51DDD92320791DEDB55");

                entity.HasIndex(e => new { e.HofId, e.DistId, e.Active }, "nci_wi_Mst_Customer_443025AFD28877A536C918B977F67366");

                entity.HasIndex(e => new { e.DistId, e.MobileNo }, "nci_wi_Mst_Customer_C06E92BD8972799B93C939ED79C809E4");

                entity.HasIndex(e => new { e.HofFlag, e.Active }, "nci_wi_Mst_Customer_F6A818598D9F815E8C88E909F1B4FB0D");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.AdharNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adhar_No");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.GaurdianName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Gaurdian_Name");

                entity.Property(e => e.GaurdianRelation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Gaurdian_Relation");

                entity.Property(e => e.HofFlag).HasColumnName("Hof_Flag");

                entity.Property(e => e.HofId).HasColumnName("Hof_Id");

                entity.Property(e => e.InactivatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inactivated_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_No");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RationCardId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RationCard_Id");

                entity.Property(e => e.RelationWithHof)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Relation_With_Hof");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<MstDist>(entity =>
            {
                entity.HasKey(e => e.DistId)
                    .HasName("PK__Mst_Dist__527E9561994E0D3B");

                entity.ToTable("Mst_Dist");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistAddress)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Address");

                entity.Property(e => e.DistBackdoor)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Backdoor");

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

                entity.Property(e => e.DistLocked).HasColumnName("Dist_Locked");

                entity.Property(e => e.DistLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Login");

                entity.Property(e => e.DistMacCheck).HasColumnName("Dist_Mac_Check");

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

                entity.Property(e => e.DistPassword)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Password");

                entity.Property(e => e.DistProfilePicPath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Dist_Profile_Pic_Path");

                entity.Property(e => e.EmailToNotify)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.MobileNoToNotifyViaSms)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<MstDoc>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK__Mst_Doc__46473BC1D466A39D");

                entity.ToTable("Mst_Doc");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DocFileName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Doc_File_Name");

                entity.Property(e => e.DocFilePath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Doc_File_Path");

                entity.Property(e => e.DocTypeId).HasColumnName("Doc_Type_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.MstDocs)
                    .HasForeignKey(d => d.DocTypeId)
                    .HasConstraintName("FK__Mst_Doc__Doc_Typ__51851410");
            });

            modelBuilder.Entity<MstDocType>(entity =>
            {
                entity.HasKey(e => e.DocTypeId)
                    .HasName("PK__Mst_Doc___EB8EF6766E8868BD");

                entity.ToTable("Mst_Doc_Type");

                entity.Property(e => e.DocTypeId).HasColumnName("Doc_Type_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DocTypeName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Type_Name");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<MstRel>(entity =>
            {
                entity.HasKey(e => e.MstRelWithHofId)
                    .HasName("PK__Mst_Rel__0A754B9EBB4CAF50");

                entity.ToTable("Mst_Rel");

                entity.Property(e => e.MstRelWithHofId).HasColumnName("Mst_Rel_With_Hof_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.Relation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<MstRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Mst_Role__D80AB4BBA7966EAE");

                entity.ToTable("Mst_Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.ControlIdToHide)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role_Desc");
            });

            modelBuilder.Entity<MstSearchCat>(entity =>
            {
                entity.HasKey(e => e.SearchCatId)
                    .HasName("PK__Mst_Sear__F93170402002BAE7");

                entity.ToTable("Mst_Search_Cat");

                entity.Property(e => e.SearchCatId).HasColumnName("Search_Cat_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.SearchCatDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Search_Cat_Desc");

                entity.Property(e => e.SearchCatKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Search_Cat_Key");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductBrandMaster>(entity =>
            {
                entity.HasKey(e => e.ProductBrandMasterIdentity)
                    .HasName("PK__Product___64FE556BE988B0A6");

                entity.ToTable("Product_Brand_Master");

                entity.Property(e => e.ProductBrandMasterIdentity).HasColumnName("Product_Brand_Master_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductBrandCompanyDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_Brand_Company_Desc");

                entity.Property(e => e.ProductBrandDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_Brand_Desc");

                entity.Property(e => e.ProductClassMasterId).HasColumnName("Product_Class_Master_Id");

                entity.Property(e => e.ProductDeptMasterId).HasColumnName("Product_Dept_Master_Id");

                entity.Property(e => e.ProductMcMasterId).HasColumnName("Product_MC_Master_Id");

                entity.Property(e => e.ProductSubClassMasterId).HasColumnName("Product_SubClass_Master_Id");

                entity.Property(e => e.ProductSubDeptMasterId).HasColumnName("Product_SubDept_Master_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductClassMaster>(entity =>
            {
                entity.HasKey(e => e.ProductClassMasterIdentity)
                    .HasName("PK__Product___6DAD44F2C026F3B2");

                entity.ToTable("Product_Class_Master");

                entity.Property(e => e.ProductClassMasterIdentity).HasColumnName("Product_Class_Master_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductClassMasterDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_Class_Master_Desc");

                entity.Property(e => e.ProductDeptMasterId).HasColumnName("Product_Dept_Master_Id");

                entity.Property(e => e.ProductSubDeptMasterId).HasColumnName("Product_SubDept_Master_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductDeptMaster>(entity =>
            {
                entity.HasKey(e => e.ProductDeptMasterIdentity)
                    .HasName("PK__Product___85F4E724C8A203E7");

                entity.ToTable("Product_Dept_Master");

                entity.Property(e => e.ProductDeptMasterIdentity).HasColumnName("Product_Dept_Master_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductDeptDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_Dept_Desc");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductInput>(entity =>
            {
                entity.HasKey(e => e.ProductInputIdentity)
                    .HasName("PK__Product___B5B3BB060B65BF38");

                entity.ToTable("Product_Input");

                entity.Property(e => e.ProductInputIdentity).HasColumnName("Product_Input_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductXml)
                    .HasColumnType("xml")
                    .HasColumnName("Product_Xml");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.HasKey(e => e.ProductMasterIdentity)
                    .HasName("PK__Product___A20BF0C8FF938983");

                entity.ToTable("Product_Master");

                entity.Property(e => e.ProductMasterIdentity).HasColumnName("Product_Master_Identity");

                entity.Property(e => e.ArticleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Article_Code");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUomId).HasColumnName("Base_UOM_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProdDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ProductBrandMasterId).HasColumnName("Product_Brand_Master_Id");

                entity.Property(e => e.ProductClassMasterId).HasColumnName("Product_Class_Master_Id");

                entity.Property(e => e.ProductDeptMasterIdentity).HasColumnName("Product_Dept_Master_Identity");

                entity.Property(e => e.ProductMcMasterId).HasColumnName("Product_MC_Master_Id");

                entity.Property(e => e.ProductRateId).HasColumnName("Product_Rate_Id");

                entity.Property(e => e.ProductSubClassMasterId).HasColumnName("Product_SubClass_Master_Id");

                entity.Property(e => e.ProductSubDeptMasterId).HasColumnName("Product_SubDept_Master_Id");

                entity.Property(e => e.Uomtype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UOMType");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductMcMaster>(entity =>
            {
                entity.HasKey(e => e.ProductMcMasterIdentity)
                    .HasName("PK__Product___82E830C18DB50DC2");

                entity.ToTable("Product_MC_Master");

                entity.Property(e => e.ProductMcMasterIdentity).HasColumnName("Product_MC_Master_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductClassMasterId).HasColumnName("Product_Class_Master_Id");

                entity.Property(e => e.ProductDeptMasterId).HasColumnName("Product_Dept_Master_Id");

                entity.Property(e => e.ProductMcCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Product_MC_Code");

                entity.Property(e => e.ProductMcMasterDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_MC_Master_Desc");

                entity.Property(e => e.ProductSubClassMasterId).HasColumnName("Product_SubClass_Master_Id");

                entity.Property(e => e.ProductSubDeptMasterId).HasColumnName("Product_SubDept_Master_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductPerCustomer>(entity =>
            {
                entity.HasKey(e => e.ProductPerCustomerIdentity)
                    .HasName("PK__Product___4D67046B7FC61926");

                entity.ToTable("Product_Per_Customer");

                entity.Property(e => e.ProductPerCustomerIdentity).HasColumnName("Product_Per_Customer_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.MstCustId).HasColumnName("Mst_Cust_Id");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.ProdQuantity).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.UomId).HasColumnName("UOM_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductQuantityMaster>(entity =>
            {
                entity.HasKey(e => e.ProductQuantityMasterIdentity)
                    .HasName("PK__Product___A821BA8C4CF2AFBE");

                entity.ToTable("Product_Quantity_Master");

                entity.Property(e => e.ProductQuantityMasterIdentity).HasColumnName("Product_Quantity_Master_Identity");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DefaultQuantityInBaseUom).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductRate>(entity =>
            {
                entity.HasKey(e => e.ProductRateIdentity)
                    .HasName("PK__Product___EC436F1FC7B579F4");

                entity.ToTable("Product_Rate");

                entity.Property(e => e.ProductRateIdentity).HasColumnName("Product_Rate_Identity");

                entity.Property(e => e.BuyingRateInBaseUom)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("Buying_Rate_In_Base_Uom");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.MrpRateInBaseUom)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("Mrp_Rate_In_Base_Uom");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.SellingRateInBaseUom)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("Selling_Rate_In_Base_Uom");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductSearchInput>(entity =>
            {
                entity.HasKey(e => e.ProductSearchInputIdentity)
                    .HasName("PK__Product___B164BD5240FB7C74");

                entity.ToTable("Product_Search_Input");

                entity.Property(e => e.ProductSearchInputIdentity).HasColumnName("Product_Search_Input_Identity");

                entity.Property(e => e.ArticleCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BarCode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrandCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Dept)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.DtFrom).HasColumnType("datetime");

                entity.Property(e => e.DtTo).HasColumnType("datetime");

                entity.Property(e => e.Mc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.McCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrdName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SubClass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubDept)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductStock>(entity =>
            {
                entity.HasKey(e => e.ProductStockIdentity)
                    .HasName("PK__Product___9E913839B25DA04C");

                entity.ToTable("Product_Stock");

                entity.Property(e => e.ProductStockIdentity).HasColumnName("Product_Stock_Identity");

                entity.Property(e => e.AllowedDamageQuantityPerUnit).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.ProdQuantity).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TotalAllowedDamageQuantity).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TotalDamageQuantityInReal).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.UomId).HasColumnName("UOM_Id");
            });

            modelBuilder.Entity<ProductStockHi>(entity =>
            {
                entity.HasKey(e => e.ProductStockHisIdentity)
                    .HasName("PK__Product___86CEEF6DA8BB039F");

                entity.ToTable("Product_Stock_His");

                entity.Property(e => e.ProductStockHisIdentity).HasColumnName("Product_Stock_his_Identity");

                entity.Property(e => e.AllowedDamageQuantityPerUnit).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.ProdQuantity).HasColumnType("decimal(4, 0)");

                entity.Property(e => e.TotalAllowedDamageQuantity).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TotalDamageQuantityInReal).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.UomId).HasColumnName("UOM_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductStockReport>(entity =>
            {
                entity.HasKey(e => e.ProductStockReportIdentity)
                    .HasName("PK__Product___55D9FD7DBB3EFDA1");

                entity.ToTable("Product_Stock_Report");

                entity.Property(e => e.ProductStockReportIdentity).HasColumnName("Product_Stock_Report_Identity");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.ClosingBalance).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.HandlingLoss).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.OpenningBalance).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.StockRecieved).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.StockSold).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TotalStock).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.UomId).HasColumnName("UOM_Id");
            });

            modelBuilder.Entity<ProductStockReportInput>(entity =>
            {
                entity.HasKey(e => e.ProductStockReportInputIdentity)
                    .HasName("PK__Product___A70E11D53283EB9E");

                entity.ToTable("Product_Stock_Report_Input");

                entity.Property(e => e.ProductStockReportInputIdentity).HasColumnName("Product_Stock_Report_Input_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.DtFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtTo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductSubClassMaster>(entity =>
            {
                entity.HasKey(e => e.ProductSubClassMasterIdentity)
                    .HasName("PK__Product___1C23B97679C0791B");

                entity.ToTable("Product_SubClass_Master");

                entity.Property(e => e.ProductSubClassMasterIdentity).HasColumnName("Product_SubClass_Master_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductClassMasterId).HasColumnName("Product_Class_Master_Id");

                entity.Property(e => e.ProductDeptMasterId).HasColumnName("Product_Dept_Master_Id");

                entity.Property(e => e.ProductSubClassMasterDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_SubClass_Master_Desc");

                entity.Property(e => e.ProductSubDeptMasterId).HasColumnName("Product_SubDept_Master_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductSubDeptMaster>(entity =>
            {
                entity.HasKey(e => e.ProductSubDeptMasterIdentity)
                    .HasName("PK__Product___F77567D964444F31");

                entity.ToTable("Product_SubDept_Master");

                entity.Property(e => e.ProductSubDeptMasterIdentity).HasColumnName("Product_SubDept_Master_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductDeptMasterId).HasColumnName("Product_Dept_Master_Id");

                entity.Property(e => e.ProductSubDeptMasterDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Product_SubDept_Master_Desc");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<ProductUom>(entity =>
            {
                entity.HasKey(e => e.ProductUomIdentity)
                    .HasName("PK__Product___FE2D1AF32C2E2C3D");

                entity.ToTable("Product_Uom");

                entity.Property(e => e.ProductUomIdentity).HasColumnName("Product_Uom_Identity");

                entity.Property(e => e.ConversionFactorWithBaseUom).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UomId).HasColumnName("Uom_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Scaleunitlimit>(entity =>
            {
                entity.ToTable("scaleunitlimits", "dss");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "TaskHosting");
            });

            modelBuilder.Entity<ScheduleTask>(entity =>
            {
                entity.HasKey(e => e.SyncGroupId);

                entity.ToTable("ScheduleTask", "dss");

                entity.Property(e => e.SyncGroupId).ValueGeneratedNever();

                entity.Property(e => e.ExpirationTime).HasColumnType("datetime");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.HasOne(d => d.SyncGroup)
                    .WithOne(p => p.ScheduleTask)
                    .HasForeignKey<ScheduleTask>(d => d.SyncGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScheduleT__SyncG");
            });

            modelBuilder.Entity<ScheduleTask1>(entity =>
            {
                entity.HasKey(e => e.ScheduleTaskId)
                    .HasName("PK__Schedule__8DAD173AC4F2A935");

                entity.ToTable("ScheduleTask", "TaskHosting");

                entity.HasIndex(e => e.MessageId, "ScheduleTask_MessageId_Index");

                entity.Property(e => e.ScheduleTaskId).ValueGeneratedNever();

                entity.Property(e => e.NextRunTime).HasColumnType("datetime");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.ScheduleNavigation)
                    .WithMany(p => p.ScheduleTask1s)
                    .HasForeignKey(d => d.Schedule)
                    .HasConstraintName("FK__ScheduleT__Sched__45FF1E22");
            });

            modelBuilder.Entity<SecurityCode>(entity =>
            {
                entity.HasKey(e => e.SecurityCodeIdentity)
                    .HasName("PK__Security__C5A04D24D2F2FF84");

                entity.ToTable("Security_Code");

                entity.Property(e => e.SecurityCodeIdentity).HasColumnName("Security_Code_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.MailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Mail_Id");

                entity.Property(e => e.SecurityCodeInMail)
                    .IsUnicode(false)
                    .HasColumnName("Security_Code_In_Mail");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Student");

                entity.Property(e => e.StudentBatch).HasMaxLength(50);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.StudentName).HasMaxLength(100);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription", "dss");

                entity.HasIndex(e => e.Syncserveruniquename, "IX_SyncServerUniqueName")
                    .IsUnique()
                    .HasFilter("([syncserveruniquename] IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Creationtime)
                    .HasColumnType("datetime")
                    .HasColumnName("creationtime");

                entity.Property(e => e.EnableDetailedProviderTracing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Lastlogintime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastlogintime");

                entity.Property(e => e.Name)
                    .HasMaxLength(140)
                    .HasColumnName("name");

                entity.Property(e => e.Policyid)
                    .HasColumnName("policyid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Subscriptionstate).HasColumnName("subscriptionstate");

                entity.Property(e => e.Syncserveruniquename)
                    .HasMaxLength(256)
                    .HasColumnName("syncserveruniquename");

                entity.Property(e => e.Tombstoneretentionperiodindays).HasColumnName("tombstoneretentionperiodindays");

                entity.Property(e => e.Version)
                    .HasMaxLength(40)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<SyncObjectDatum>(entity =>
            {
                entity.HasKey(e => new { e.ObjectId, e.DataType })
                    .HasName("PK_SyncObjectExtInfo");

                entity.ToTable("SyncObjectData", "dss");

                entity.Property(e => e.CreatedTime).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LastModified)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ObjectData).IsRequired();
            });

            modelBuilder.Entity<Syncgroup>(entity =>
            {
                entity.ToTable("syncgroup", "dss");

                entity.HasIndex(e => e.HubMemberid, "index_syncgroup_hub_memberid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ConflictResolutionPolicy).HasColumnName("conflict_resolution_policy");

                entity.Property(e => e.ConflictTableRetentionInDays).HasDefaultValueSql("((30))");

                entity.Property(e => e.HubMemberid).HasColumnName("hub_memberid");

                entity.Property(e => e.Hubhasdata).HasColumnName("hubhasdata");

                entity.Property(e => e.Lastupdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdatetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(140)
                    .HasColumnName("name");

                entity.Property(e => e.Ocsschemadefinition).HasColumnName("ocsschemadefinition");

                entity.Property(e => e.SchemaDescription)
                    .HasColumnType("xml")
                    .HasColumnName("schema_description");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

                entity.Property(e => e.SyncEnabled)
                    .IsRequired()
                    .HasColumnName("sync_enabled")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SyncInterval).HasColumnName("sync_interval");

                entity.HasOne(d => d.HubMember)
                    .WithMany(p => p.Syncgroups)
                    .HasForeignKey(d => d.HubMemberid)
                    .HasConstraintName("FK__syncgroup__hub_m");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Syncgroups)
                    .HasForeignKey(d => d.Subscriptionid)
                    .HasConstraintName("FK__syncgroup__subsc");
            });

            modelBuilder.Entity<Syncgroupmember>(entity =>
            {
                entity.ToTable("syncgroupmember", "dss");

                entity.HasIndex(e => new { e.Syncgroupid, e.Databaseid }, "IX_SyncGroupMember_SyncGroupId_DatabaseId")
                    .IsUnique();

                entity.HasIndex(e => e.Databaseid, "index_syncgroupmember_databaseid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Databaseid).HasColumnName("databaseid");

                entity.Property(e => e.HubJobId).HasColumnName("hubJobId");

                entity.Property(e => e.Hubstate).HasColumnName("hubstate");

                entity.Property(e => e.HubstateLastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("hubstate_lastupdated")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.Lastsynctime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastsynctime");

                entity.Property(e => e.LastsynctimeZerofailuresHub)
                    .HasColumnType("datetime")
                    .HasColumnName("lastsynctime_zerofailures_hub");

                entity.Property(e => e.LastsynctimeZerofailuresMember)
                    .HasColumnType("datetime")
                    .HasColumnName("lastsynctime_zerofailures_member");

                entity.Property(e => e.Memberhasdata).HasColumnName("memberhasdata");

                entity.Property(e => e.Memberstate).HasColumnName("memberstate");

                entity.Property(e => e.MemberstateLastupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("memberstate_lastupdated")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(140)
                    .HasColumnName("name");

                entity.Property(e => e.Noinitsync).HasColumnName("noinitsync");

                entity.Property(e => e.Scopename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("scopename")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Syncdirection).HasColumnName("syncdirection");

                entity.Property(e => e.Syncgroupid).HasColumnName("syncgroupid");

                entity.HasOne(d => d.Database)
                    .WithMany(p => p.Syncgroupmembers)
                    .HasForeignKey(d => d.Databaseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__syncmember__datab");

                entity.HasOne(d => d.Syncgroup)
                    .WithMany(p => p.Syncgroupmembers)
                    .HasForeignKey(d => d.Syncgroupid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__syncmember__syncg");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task", "dss");

                entity.HasIndex(e => e.Actionid, "index_task_actionid");

                entity.HasIndex(e => new { e.Agentid, e.State }, "index_task_agentid_state")
                    .HasFilter("([state]=(0))");

                entity.HasIndex(e => e.Completedtime, "index_task_completedtime");

                entity.HasIndex(e => new { e.State, e.Agentid, e.DependencyCount, e.Priority, e.Creationtime }, "index_task_gettask");

                entity.HasIndex(e => new { e.State, e.Completedtime }, "index_task_state")
                    .HasFilter("([state]=(2))");

                entity.HasIndex(e => new { e.Lastheartbeat, e.State }, "index_task_state_lastheartbeat")
                    .HasFilter("([state]<(0))");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Actionid).HasColumnName("actionid");

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.Completedtime)
                    .HasColumnType("datetime")
                    .HasColumnName("completedtime");

                entity.Property(e => e.Creationtime)
                    .HasColumnType("datetime")
                    .HasColumnName("creationtime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DependencyCount).HasColumnName("dependency_count");

                entity.Property(e => e.Lastheartbeat)
                    .HasColumnType("datetime")
                    .HasColumnName("lastheartbeat");

                entity.Property(e => e.Lastresettime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastresettime");

                entity.Property(e => e.OwningInstanceid).HasColumnName("owning_instanceid");

                entity.Property(e => e.Pickuptime)
                    .HasColumnType("datetime")
                    .HasColumnName("pickuptime");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.Request).HasColumnName("request");

                entity.Property(e => e.Response).HasColumnName("response");

                entity.Property(e => e.RetryCount).HasColumnName("retry_count");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaskNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("taskNumber");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Actionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__task__actionid");
            });

            modelBuilder.Entity<Taskdependency>(entity =>
            {
                entity.HasKey(e => new { e.Nexttaskid, e.Prevtaskid })
                    .HasName("PK_TaskTask");

                entity.ToTable("taskdependency", "dss");

                entity.Property(e => e.Nexttaskid).HasColumnName("nexttaskid");

                entity.Property(e => e.Prevtaskid).HasColumnName("prevtaskid");

                entity.HasOne(d => d.Nexttask)
                    .WithMany(p => p.TaskdependencyNexttasks)
                    .HasForeignKey(d => d.Nexttaskid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__taskdepen__nextt");

                entity.HasOne(d => d.Prevtask)
                    .WithMany(p => p.TaskdependencyPrevtasks)
                    .HasForeignKey(d => d.Prevtaskid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__taskdepen__prevt");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherBatches).HasMaxLength(50);

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.TeacherName).HasMaxLength(100);

                entity.Property(e => e.TeacherSkills).HasMaxLength(50);
            });

            modelBuilder.Entity<TxnCardInputDatum>(entity =>
            {
                entity.ToTable("Txn_Card_Input_Data");

                entity.Property(e => e.Active)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ActiveInactivatedDate)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Active_Inactivated_Date");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.AdharNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adhar_No");

                entity.Property(e => e.Age)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CardCategoryDesc)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Card_Category_Desc");

                entity.Property(e => e.CardCategoryId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Card_Category_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Id");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.GaurdianName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Gaurdian_Name");

                entity.Property(e => e.GaurdianRelationDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Gaurdian_Relation_Desc");

                entity.Property(e => e.GaurdianRelationId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Gaurdian_Relation_Id");

                entity.Property(e => e.HofFlag)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Hof_Flag");

                entity.Property(e => e.HofId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Hof_Id");

                entity.Property(e => e.HofName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Hof_Name");

                entity.Property(e => e.MacId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Mobile_No");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RationCardId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RationCard_Id");

                entity.Property(e => e.RelationWithHofDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Relation_With_Hof_Desc");

                entity.Property(e => e.RelationWithHofId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Relation_With_Hof_Id");

                entity.Property(e => e.Remarks).IsUnicode(false);
            });

            modelBuilder.Entity<TxnRationCard>(entity =>
            {
                entity.HasKey(e => e.RationCardId)
                    .HasName("PK__Txn_Rati__A11C32B81D9994E6");

                entity.ToTable("Txn_RationCard");

                entity.HasIndex(e => e.CustomerId, "nci_wi_Txn_RationCard_73FBBFBC3EA1BCF5DFFE193929E25EFE");

                entity.Property(e => e.RationCardId).HasColumnName("RationCard_Id");

                entity.Property(e => e.CardCategoryId).HasColumnName("Card_Category_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.InactivatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inactivated_Date");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.Number)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Uihistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UIHistory", "dss");

                entity.HasIndex(e => e.Agentid, "Idx_UIHistory_AgentId");

                entity.HasIndex(e => e.CompletionTime, "Idx_UIHistory_CompletionTime");

                entity.HasIndex(e => e.Databaseid, "Idx_UIHistory_DatabaseId");

                entity.HasIndex(e => e.Id, "Idx_UIHistory_Id");

                entity.HasIndex(e => e.Serverid, "Idx_UIHistory_ServerId")
                    .IsClustered();

                entity.HasIndex(e => e.SyncgroupId, "Idx_UIHistory_SyncgroupId");

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.CompletionTime).HasColumnName("completionTime");

                entity.Property(e => e.Databaseid).HasColumnName("databaseid");

                entity.Property(e => e.DetailEnumId)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("detailEnumId");

                entity.Property(e => e.DetailStringParameters).HasColumnName("detailStringParameters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsWritable)
                    .HasColumnName("isWritable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RecordType).HasColumnName("recordType");

                entity.Property(e => e.Serverid).HasColumnName("serverid");

                entity.Property(e => e.SyncgroupId).HasColumnName("syncgroupId");

                entity.Property(e => e.TaskType).HasColumnName("taskType");
            });

            modelBuilder.Entity<Uom>(entity =>
            {
                entity.HasKey(e => e.UomIdIdentity)
                    .HasName("PK__UOM__BDA7019B45D8A79D");

                entity.ToTable("UOM");

                entity.Property(e => e.UomIdIdentity).HasColumnName("UOM_Id_Identity");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DistId).HasColumnName("Dist_Id");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Updated_Date");

                entity.Property(e => e.Uomname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UOMName");

                entity.Property(e => e.Uomtype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UOMType");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Updated_By");
            });

            modelBuilder.Entity<Userdatabase>(entity =>
            {
                entity.ToTable("userdatabase", "dss");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Agentid).HasColumnName("agentid");

                entity.Property(e => e.ConnectionString).HasColumnName("connection_string");

                entity.Property(e => e.Database)
                    .HasMaxLength(256)
                    .HasColumnName("database");

                entity.Property(e => e.DbSchema).HasColumnName("db_schema");

                entity.Property(e => e.IsOnPremise).HasColumnName("is_on_premise");

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.LastSchemaUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("last_schema_updated");

                entity.Property(e => e.LastTombstonecleanup)
                    .HasColumnType("datetime")
                    .HasColumnName("last_tombstonecleanup");

                entity.Property(e => e.Region)
                    .HasMaxLength(256)
                    .HasColumnName("region");

                entity.Property(e => e.Server)
                    .HasMaxLength(256)
                    .HasColumnName("server");

                entity.Property(e => e.SqlazureInfo)
                    .HasColumnType("xml")
                    .HasColumnName("sqlazure_info");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Userdatabases)
                    .HasForeignKey(d => d.Subscriptionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__userdatab__subsc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

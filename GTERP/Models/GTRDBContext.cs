
using GTERP.Models.Buffers;
using GTERP.Models.BufferSalesReportInput;
using GTERP.Models.FactoryDapInfo;
using GTERP.Models.OpeningBalance;
using GTERP.Models.ReceivedFromBufferBankAmountModel;
using Microsoft.EntityFrameworkCore;
//using AlanJuden.MvcReportViewer;

namespace GTERP.Models
{


    public partial class GTRDBContext : DbContext
    {

        public GTRDBContext()
            : base()
        {
            //Database.SetCommandTimeout(150000);
        }

        public GTRDBContext(DbContextOptions<GTRDBContext> options)
            : base(options)
        {
            //Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
            //options.UseSqlServer(connection, b => b.MigrationsAssembly("GTReportService"));
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SalesSub>().HasKey(c => new { c.SalesId, c.SalesTypeId, c.ProductId, c.ProductDescription, c.ProductSerialId });
            modelBuilder.Entity<SalesSub>().HasKey(c => new { c.SalesId, c.ProductId, c.ProductDescription });

            modelBuilder.Entity<SalesTermsSub>().HasKey(c => new { c.SalesId, c.Terms, c.Description });
            modelBuilder.Entity<SalesPaymentSub>().HasKey(c => new { c.SalesId, c.PaymentTypeId, c.AccId });





            //modelBuilder.Entity<Acc_VoucherTranGroup>().HasKey(c => new { c.VoucherId, c.VoucherTranGroupId});



            //modelBuilder.Entity<Acc_VoucherTranGroup>(entity =>
            //{
            //    entity.HasKey(e => new { e.VoucherId, e.VoucherTranGroupId });

            //    entity.HasIndex(e => e.VoucherId);

            //    //entity.HasOne(d => d.Role)
            //    //    .WithMany(p => p.AspNetUserRoles)
            //    //    .HasForeignKey(d => d.RoleId);

            //    //entity.HasOne(d => d.User)
            //    //    .WithMany(p => p.AspNetUserRoles)
            //    //    .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<PurchaseSub>().HasKey(c => new { c.PurchaseId, c.SalesTypeId, c.ProductId, c.ProductDescription, c.ProductSerialId });
            //modelBuilder.Entity<PurchaseTermsSub>().HasKey(c => new { c.PurchaseId, c.Terms, c.Description });
            //modelBuilder.Entity<PurchasePaymentSub>().HasKey(c => new { c.PurchaseId, c.PaymentTypeId, c.AccId });

            //modelBuilder.Entity<SalesReturnSub>().HasKey(c => new { c.SalesReturnId, c.SalesTypeId, c.ProductId, c.ProductDescription, c.ProductSerialId });
            //modelBuilder.Entity<SalesReturnTermsSub>().HasKey(c => new { c.SalesReturnId, c.Terms, c.Description });
            //modelBuilder.Entity<SalesReturnPaymentSub>().HasKey(c => new { c.SalesReturnId, c.PaymentTypeId, c.AccId });

            //modelBuilder.Entity<PurchaseReturnSub>().HasKey(c => new { c.PurchaseReturnId, c.SalesTypeId, c.ProductId, c.ProductDescription, c.ProductSerialId });
            //modelBuilder.Entity<PurchaseReturnTermsSub>().HasKey(c => new { c.PurchaseReturnId, c.Terms, c.Description });
            //modelBuilder.Entity<PurchaseReturnPaymentSub>().HasKey(c => new { c.PurchaseReturnId, c.PaymentTypeId, c.AccId });

            //modelBuilder.Entity<Acc_VoucherSub>().HasKey(c => new { c.VoucherId, c.AccId });
            //modelBuilder.Entity<Acc_VoucherSubSection>().HasKey(c => new { c.VoucherId, c.SubSectId });
            //modelBuilder.Entity<Acc_VoucherSubChecno>().HasKey(c => new { c.VoucherId , c.AccId, c.VoucherSubId});

            //modelBuilder.Entity<Product>().HasKey(c => new { c.comid, c.ProductCode});

            // modelBuilder.Entity<Product>()
            //.HasIndex(u => u.ProductCode , u.com)
            //.IsUnique();


            // modelBuilder.Entity<Product>()
            //.HasIndex(u => u.ProductName)
            //.IsUnique();

            modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.comid, p.ProductCode })
            .IsUnique(true);

            modelBuilder.Entity<Customer>()
            .HasIndex(p => new { p.comid, p.CustomerCode })
            .IsUnique(true);

            modelBuilder.Entity<Supplier>()
            .HasIndex(p => new { p.comid, p.SupplierCode })
            .IsUnique(true);


            modelBuilder.Entity<Acc_ChartOfAccount>()
            .HasIndex(p => new { p.comid, p.AccCode })
            .IsUnique(true);

            modelBuilder.Entity<PF_ChartOfAccount>()
            .HasIndex(p => new { p.comid, p.AccCode })
            .IsUnique(true);


            modelBuilder.Entity<Acc_VoucherMain>()
            .HasIndex(p => new { p.comid, p.VoucherNo, p.FiscalYearId, p.FiscalMonthId })
            .IsUnique(true);

            modelBuilder.Entity<PF_VoucherMain>()
            .HasIndex(p => new { p.comid, p.VoucherNo, p.FiscalYearId, p.FiscalMonthId })
            .IsUnique(true);


            modelBuilder.Entity<Booking>()
            .HasIndex(p => new { p.ComId, p.FiscalYearId, p.FiscalMonthId, p.CustomerId, p.AllotmentType })
            .IsUnique(true);


            modelBuilder.Entity<DeliveryOrder>()
            .HasIndex(p => new { p.ComId, p.DONo })
            .IsUnique(true);


            modelBuilder.Entity<DeliveryChallan>()
            .HasIndex(p => new { p.ComId, p.ChallanNo })
            .IsUnique(true);


            modelBuilder.Entity<GatePass>()
            .HasIndex(p => new { p.ComId, p.GatePassNo })
            .IsUnique(true);



            modelBuilder.Entity<PurchaseRequisitionMain>()
            .HasIndex(p => new { p.ComId, p.PRNo })
            .IsUnique(true);

            modelBuilder.Entity<PurchaseOrderMain>()
            .HasIndex(p => new { p.ComId, p.PONo })
            .IsUnique(true);

            modelBuilder.Entity<GoodsReceiveMain>()
            .HasIndex(p => new { p.ComId, p.GRRNo })
            .IsUnique(true);

            modelBuilder.Entity<StoreRequisitionMain>()
            .HasIndex(p => new { p.ComId, p.FiscalYearId, p.SRNo })
            .IsUnique(true);



            //modelBuilder.Entity<IssueMain>()
            //.HasIndex(p => new { p.ComId, p.IssueNo , p.FiscalYearId })
            //.IsUnique(true);

            modelBuilder.Entity<IssueMain>()
            .HasIndex(p => new { p.IssueNo, p.FiscalYearId, p.ComId }).IsUnique();


            modelBuilder.Entity<Inventory>()
            .HasIndex(p => new { p.comid, p.ProductId, p.WareHouseId })
            .IsUnique(true);


            modelBuilder.Entity<MonthlySalesProduction>()
            .HasIndex(p => new { p.ComId, p.FiscalYearId, p.FiscalMonthId })
            .IsUnique(true);

            modelBuilder.Entity<ReorderLevel>()
           .HasIndex(p => new { p.ComId, p.ProductId, p.WarehouseId })
           .IsUnique(true);

            modelBuilder.Entity<UserPermission>()
           .HasIndex(p => new { p.ComId, p.EmpId, p.AppUserId })
           .IsUnique(true);



            //modelBuilder.Entity<IssueMain>()
            //.HasIndex(p => new { p.ComId, p.INNo , p.FiscalYearId })
            //.IsUnique(true);///need to add for fahad

            // modelBuilder.Entity<CostCalculated>()
            //.HasIndex(p => new { p.comid, p.ProductId, p.WarehouseId, p.GRRMainId, p })
            //.IsUnique(true);

            //modelBuilder.Entity<Acc_VoucherMain>().
            //  Property(p => p.VoucherDate)
            //  .HasColumnType("date");

        }

        //[DbFunction(Schema = "")]
        //public static string Format(DateTime data, string format)
        //{
        //    throw new Exception();
        //}
        // DAP Model               
        public virtual DbSet<Cat_Department> Cat_Department { get; set; }
        public virtual DbSet<Cat_Section> Cat_Section { get; set; }
        public virtual DbSet<Cat_SubSection> Cat_SubSection { get; set; }
        public virtual DbSet<Cat_Designation> Cat_Designation { get; set; }

        public virtual DbSet<Cat_Religion> Cat_Religion { get; set; }
        public virtual DbSet<Cat_BloodGroup> Cat_BloodGroup { get; set; }
        public virtual DbSet<Cat_Grade> Cat_Grade { get; set; }
        public virtual DbSet<Cat_Line> Cat_Line { get; set; }

        public virtual DbSet<Cat_Shift> Cat_Shift { get; set; }
        public virtual DbSet<Cat_Floor> Cat_Floor { get; set; }
        public virtual DbSet<Cat_Unit> Cat_Unit { get; set; }
        public virtual DbSet<Cat_District> Cat_District { get; set; }

        public virtual DbSet<Cat_BusStop> Cat_BusStop { get; set; }
        public virtual DbSet<Cat_ExchangeRate> Cat_ExchangeRate { get; set; }

        public virtual DbSet<Cat_BuildingType> Cat_BuildingType { get; set; }

        public virtual DbSet<Cat_PoliceStation> Cat_PoliceStation { get; set; }
        public virtual DbSet<Cat_PostOffice> Cat_PostOffice { get; set; }
        public virtual DbSet<Cat_IncenBand> Cat_IncenBand { get; set; }
        public virtual DbSet<Cat_Catagory> Cat_Catagory { get; set; }
        public virtual DbSet<Cat_InsurGrade> Cat_InsurGrade { get; set; }
        public virtual DbSet<Cat_Bank> Cat_Bank { get; set; }
        public virtual DbSet<Cat_BankBranch> Cat_BankBranch { get; set; }
        public virtual DbSet<Cat_Gender> Cat_Gender { get; set; }
        public virtual DbSet<Cat_Leave_Type> Cat_Leave_Type { get; set; }
        public virtual DbSet<Cat_Emp_Type> Cat_Emp_Type { get; set; }
        public virtual DbSet<Cat_AttStatus> Cat_AttStatus { get; set; }
        public virtual DbSet<Cat_Location> Cat_Location { get; set; }
        public virtual DbSet<Cat_AccountType> Cat_AccountType { get; set; }
        public virtual DbSet<Cat_PayMode> Cat_PayMode { get; set; }
        public virtual DbSet<Cat_Variable> Cat_Variable { get; set; }

        public virtual DbSet<Cat_MedicalDiagnosis> Cat_MedicalDiagnosis { get; set; }
        public virtual DbSet<Cat_HRSetting> Cat_HRSetting { get; set; }
        public virtual DbSet<Cat_HRExpSetting> Cat_HRExpSetting { get; set; }
        public virtual DbSet<Cat_GasChargeSetting> Cat_GasChargeSetting { get; set; }
        public virtual DbSet<Cat_ElectricChargeSetting> Cat_ElectricChargeSetting { get; set; }
        public virtual DbSet<Cat_SummerWinterAllowanceSetting> Cat_SummerWinterAllowanceSetting { get; set; }
        public virtual DbSet<Cat_Skill> Cat_Skill { get; set; }
        public virtual DbSet<Cat_ITaxBank> Cat_ITaxBank { get; set; }
        public virtual DbSet<Cat_ReportSignatory> Cat_ReportSignatory { get; set; }
        public virtual DbSet<HR_ProssType_WHDay> HR_ProssType_WHDay { get; set; }



        public virtual DbSet<Cat_Integration_Setting_Main> Cat_Integration_Setting_Mains { get; set; }
        public virtual DbSet<Cat_Integration_Setting_Details> Cat_Integration_Setting_Details { get; set; }

        public virtual DbSet<Cat_PayrollIntegrationSummary> Cat_PayrollIntegrationSummary { get; set; }

        public virtual DbSet<Cat_PFIntegrationSummary> Cat_PFIntegrationSummary { get; set; }

        public virtual DbSet<Cat_WFFIntegrationSummary> Cat_WFFIntegrationSummary { get; set; }
        public virtual DbSet<Cat_GTFIntegrationSummary> Cat_GTFIntegrationSummary { get; set; }














        //Temp Table

        public virtual DbSet<HR_Emp_TempIdCard> HR_Emp_TempIdCard { get; set; }

        //payroll Part
        //public virtual DbSet<SalaryProcess> SalaryProcesses { get; set; }
        public virtual DbSet<Payroll_SalaryDeduction> Payroll_SalaryDeduction { get; set; }


        //HR Part

        public DbSet<HR_Emp_Info> HR_Emp_Info { get; set; }
        public DbSet<HR_Emp_Address> HR_Emp_Address { get; set; }
        public DbSet<HR_Emp_Education> HR_Emp_Education { get; set; }
        public DbSet<HR_Emp_Experience> HR_Emp_Experience { get; set; }
        public DbSet<HR_Emp_Family> HR_Emp_Family { get; set; }
        public DbSet<HR_Emp_Nominee> HR_Emp_Nominee { get; set; }
        public DbSet<HR_Emp_PersonalInfo> HR_Emp_PersonalInfo { get; set; }
        public DbSet<HR_Leave_Avail> HR_Leave_Avail { get; set; }
        public DbSet<HR_Leave_Balance> HR_Leave_Balance { get; set; }
        public DbSet<HR_Emp_Increment> HR_Emp_Increment { get; set; }
        public DbSet<HR_Emp_Image> HR_Emp_Image { get; set; }
        public DbSet<HR_Emp_Released> HR_Emp_Released { get; set; }
        public DbSet<HR_ProcessedData> HR_ProcessedData { get; set; }
        public DbSet<HR_AttFixed> HR_AttFixed { get; set; }
        public DbSet<HR_Emp_Salary> HR_Emp_Salary { get; set; }
        public DbSet<HR_Emp_ArrearBill> HR_Emp_ArrearBill { get; set; }
        public DbSet<HR_TempCount> HR_TempCount { get; set; }
        public DbSet<HR_ProssType> HR_ProssType { get; set; }
        public DbSet<HR_TempJob> HR_TempJob { get; set; }
        public DbSet<HR_IncType> HR_IncType { get; set; }
        public DbSet<HR_Emp_ShiftInput> HR_Emp_ShiftInput { get; set; }
        public DbSet<HR_Emp_BankInfo> HR_Emp_BankInfo { get; set; }
        public DbSet<HR_ReportType> HR_ReportType { get; set; }
        public DbSet<HR_ProcessLock> HR_ProcessLock { get; set; }
        public DbSet<HR_Emp_PF_OPBal> HR_Emp_PF_OPBal { get; set; }

        public DbSet<HR_Loan_HouseBuilding> HR_Loan_HouseBuilding { get; set; }

        public DbSet<HR_Loan_Data_HouseBuilding> HR_Loan_Data_HouseBuilding { get; set; }


        public DbSet<HR_Loan_Welfare> HR_Loan_Welfare { get; set; }
        public DbSet<HR_Loan_Data_Welfare> HR_Loan_Data_Welfare { get; set; }
        public DbSet<HR_Loan_MotorCycle> HR_Loan_MotorCycle { get; set; }
        public DbSet<HR_Loan_Data_MotorCycle> HR_Loan_Data_MotorCycle { get; set; }
        public DbSet<HR_Loan_PF> HR_Loan_PF { get; set; }
        public DbSet<HR_Loan_Data_PF> HR_Loan_Data_PF { get; set; }
        public DbSet<HR_Loan_Other> HR_Loan_Other { get; set; }
        public DbSet<HR_Loan_Data_Other> HR_Loan_Data_Other { get; set; }
        public DbSet<HR_OT_FC> HR_OT_FC { get; set; }
        public DbSet<HR_Emp_Recreation> HR_Emp_Recreation { get; set; }
        public DbSet<HR_Emp_BusinessAllow> HR_Emp_BusinessAllow { get; set; }
        public DbSet<HR_Emp_Document> HR_Emp_Document { get; set; }
        public DbSet<HR_Loan_IncreaseInfo> HR_Loan_IncreaseInfo { get; set; }
        public DbSet<HR_SummerWinterAllowance> HR_SummerWinterAllowance { get; set; }
        public DbSet<HR_LvEncashment> HR_LvEncashment { get; set; }
        public DbSet<HR_Emp_Suppliment> HR_Emp_Suppliment { get; set; }
        public DbSet<HR_OtherDedAssociation> HR_OtherDedAssociation { get; set; }
        public DbSet<HR_Employee_VariablePermission> HR_Employee_VariablePermission { get; set; }
        public DbSet<HR_Loan_Return> HR_Loan_Return { get; set; }

        // Medical

        public DbSet<Medical_Master> Medical_Master { get; set; }
        public DbSet<Medical_Details> Medical_Details { get; set; }
        public DbSet<ReorderLevel> ReorderLevel { get; set; }

        //Production 
        //public DbSet<LabourStrike> LabourStrike { get; set; }
        public DbSet<DownTime> DownTime { get; set; }
        public DbSet<ProductionTargetSetup> ProductionTargetSetup { get; set; }
        public DbSet<SalesTargetSetup> SalesTargetSetup { get; set; }
        public DbSet<MonthlySalesProduction> MonthlySalesProductions { get; set; }


        public DbSet<UseUtilities> UseUtilities { get; set; }
        public DbSet<DownTimeReason> DownTimeReason { get; set; }
        public DbSet<RawMaterialStock> RawMaterialStock { get; set; }
        public DbSet<BOMMain> BOMMain { get; set; }
        public DbSet<BOMSub> BOMSub { get; set; }



        //Account
        public DbSet<PrdUnit> PrdUnits { get; set; }
        public DbSet<ShareHolding> ShareHoldings { get; set; }
        public DbSet<NoteDescription> NoteDescriptions { get; set; }



        public DbSet<Acc_VoucherNoPrefix> Acc_VoucherNoPrefixes { get; set; }
        public DbSet<Acc_VoucherNoCreatedType> Acc_VoucherNoCreatedTypes { get; set; }

        // Commercial 
        public DbSet<BusinessType> BusinessType { get; set; }
        public DbSet<Company> Companys { get; set; }
        //public DbSet<Company> BasedCompnay { get; set; }

        public DbSet<SalesMain> SalesMains { get; set; }
        public DbSet<SalesSub> SalesSubs { get; set; }

        public DbSet<SalesPaymentSub> SalesPaymentSubs { get; set; }

        public DbSet<SalesTermsSub> SalesTermsSubs { get; set; }

        public DbSet<SalesReturnMain> SalesReturnMains { get; set; }
        public DbSet<SalesReturnSub> SalesReturnSubs { get; set; }
        public DbSet<SalesReturnPaymentSub> SalesReturnPaymentSubs { get; set; }
        public DbSet<SalesReturnTermsSub> SalesReturnTermsSubs { get; set; }

        public DbSet<PurchaseOrderValidMain> PurchaseOrderValidMains { get; set; }
        public DbSet<PurchaseOrderValidSub> PurchaseOrderValidSubs { get; set; }
        public DbSet<PurchaseOrderValidSubSupplier> PurchaseOrderValidSubSuppliers { get; set; }


        public DbSet<PurchaseMain> PurchaseMains { get; set; }
        public DbSet<PurchaseSub> PurchaseSubs { get; set; }
        public DbSet<PurchasePaymentSub> PurchasePaymentSubs { get; set; }
        public DbSet<PurchaseTermsSub> PurchaseTermsSubs { get; set; }


        public DbSet<ProductSerial> ProductSerial { get; set; }

        public DbSet<PurchaseReturnMain> PurchaseReturnMains { get; set; }
        public DbSet<PurchaseReturnSub> PurchaseReturnSubs { get; set; }
        public DbSet<PurchaseReturnPaymentSub> PurchaseReturnPaymentSubs { get; set; }
        public DbSet<PurchaseReturnTermsSub> PurchaseReturnTermsSubs { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductMainGroup> ProductMainGroups { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrie> ProductPrice { get; set; }


        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<CostCalculated> CostCalculated { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }

        public DbSet<PurchaseRequisitionMain> PurchaseRequisitionMain { get; set; }
        public DbSet<PurchaseRequisitionSub> PurchaseRequisitionSub { get; set; }
        public DbSet<PurchaseOrderMain> PurchaseOrderMain { get; set; }
        public DbSet<PurchaseOrderSub> PurchaseOrderSub { get; set; }
        public DbSet<GoodsReceiveMain> GoodsReceiveMain { get; set; }
        public DbSet<GoodsReceiveSub> GoodsReceiveSub { get; set; }
        public DbSet<GoodsReceiveProvision> GoodsReceiveProvision { get; set; }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<DistrictWiseBooking> DistrictWiseBooking { get; set; }

        public DbSet<DeliveryOrder> DeliveryOrder { get; set; }
        public DbSet<Representative> Representative { get; set; }
        public DbSet<DeliveryChallan> DeliveryChallan { get; set; }


        public DbSet<Cat_IncomeTaxChk> Cat_IncomeTaxChk { get; set; }
        public DbSet<Cat_ITComputationSetting> Cat_ITComputationSetting { get; set; }
        public DbSet<Purpose> Purpose { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<SupplierContact> SupplierContacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<JobNo> jobno { get; set; }
        //public virtual DbSet<CityViewModel> CityViewModel { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        //public DbSet<SisterConcern> SisterConcerns { get; set; }
        public DbSet<UserCompanyPermission> UserCompanyPermissions { get; set; }
        public DbSet<User> LoginUser { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<SalesType> SalesType { get; set; }
        public DbSet<Acc_ChartOfAccount> Acc_ChartOfAccounts { get; set; }
        public DbSet<PF_ChartOfAccount> PF_ChartOfAccounts { get; set; }
        public DbSet<WFF_ChartOfAccount> WFF_ChartOfAccounts { get; set; }
        public DbSet<GTF_ChartOfAccount> GTF_ChartOfAccounts { get; set; }
        public DbSet<Acc_ChartOfAccount_Initial> Acc_ChartOfAccount_Initials { get; set; }
        public DbSet<Acc_BudgetRelease> Acc_BudgetRelease { get; set; }

        public DbSet<TermsMain> TermsMain { get; set; }
        public DbSet<TermsSub> TermsSub { get; set; }
        public DbSet<TermsSerialSub> TermsSerialSub { get; set; }
        public DbSet<HomeSlider> HomeSlider { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Warrenty> Warrenty { get; set; }
        public DbSet<AttachmentMain> AttachmentMains { get; set; }
        public DbSet<AttachmentSub> AttachmentSubs { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }
        public DbSet<CustomerSerial> CustomerSerials { get; set; }
        public DbSet<SmsSetting> smssettings { get; set; }
        public DbSet<SoftwarePackage> SoftwarePackages { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        public DbSet<ProductRegistration> ProductRegistrations { get; set; }
        public DbSet<CompanyPermission> CompanyPermissions { get; set; }
        public DbSet<ReportPermissions> ReportPermissions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleGroup> ModuleGroups { get; set; }
        public DbSet<ModuleMenu> ModuleMenus { get; set; }
        public DbSet<MenuPermission_Master> MenuPermissionMasters { get; set; }
        public DbSet<MenuPermission_Details> MenuPermissionDetails { get; set; }
        public DbSet<Acc_FiscalYear> Acc_FiscalYears { get; set; }
        public DbSet<Acc_FiscalHalfYear> Acc_FiscalHalfYears { get; set; }
        public DbSet<Acc_FiscalQtr> Acc_FiscalQtrs { get; set; }
        public DbSet<Acc_FiscalMonth> Acc_FiscalMonths { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<InvoiceMain> InvoiceMains { get; set; }
        public DbSet<InvoiceSub> InvoiceSubs { get; set; }
        public DbSet<InvoiceTermsSub> InvoiceTermsSubs { get; set; }
        public DbSet<MonthName> MonthNames { get; set; }
        public DbSet<YearName> YearNames { get; set; }


        public DbSet<Acc_VoucherMain> Acc_VoucherMains { get; set; }
        public DbSet<Acc_VoucherSub> Acc_VoucherSubs { get; set; }
        public DbSet<Acc_VoucherSubSection> Acc_VoucherSubSections { get; set; }
        public DbSet<Acc_VoucherSubCheckno> Acc_VoucherSubChecnos { get; set; }
        public DbSet<Acc_VoucherTranGroup> Acc_VoucherTranGroups { get; set; }
        public DbSet<VoucherTranGroup> VoucherTranGroups { get; set; }

        public DbSet<Acc_BankStatementBalance> Acc_BankStatementBalances { get; set; }

        public DbSet<PF_VoucherMain> PF_VoucherMains { get; set; }
        public DbSet<PF_VoucherSub> PF_VoucherSubs { get; set; }
        public DbSet<PF_VoucherSubCheckno> PF_VoucherSubChecnos { get; set; }
        public DbSet<PF_VoucherSubSection> PF_VoucherSubSections { get; set; }

        public DbSet<WFF_VoucherMain> WFF_VoucherMains { get; set; }
        public DbSet<WFF_VoucherSub> WFF_VoucherSubs { get; set; }
        public DbSet<WFF_VoucherSubCheckno> WFF_VoucherSubChecnos { get; set; }
        public DbSet<WFF_VoucherSubSection> WFF_VoucherSubSections { get; set; }

        public DbSet<GTF_VoucherMain> GTF_VoucherMains { get; set; }
        public DbSet<GTF_VoucherSub> GTF_VoucherSubs { get; set; }
        public DbSet<GTF_VoucherSubCheckno> GTF_VoucherSubChecnos { get; set; }
        public DbSet<GTF_VoucherSubSection> GTF_VoucherSubSections { get; set; }


        public DbSet<BudgetMain> BudgetMains { get; set; }
        public DbSet<BudgetDetails> BudgetDetails { get; set; }

        public DbSet<CostAllocation_Main> CostAllocation_Main { get; set; }
        public DbSet<CostAllocation_Details> CostAllocation_Details { get; set; }
        public DbSet<CostAllocation_Distribute> CostAllocation_Distribute { get; set; }

        public DbSet<Bill_Main> Bill_Main { get; set; }
        public DbSet<Bill_Sub> Bill_Sub { get; set; }


        public DbSet<Acc_GovtSchedule_Equity> Acc_GovtSchedule_Equity { get; set; }
        public DbSet<Acc_Contingent_Liability> Acc_Contingent_Liabilities { get; set; }

        public DbSet<Acc_GovtSchedule_Loan> Acc_GovtSchedule_Loans { get; set; }

        public DbSet<Acc_GovtSchedule_ForeignLoan> Acc_GovtSchedule_ForeignLoans { get; set; }
        public DbSet<Acc_GovtSchedule_JapanLoan> Acc_GovtSchedule_JapanLoans { get; set; }
        public DbSet<Acc_AdvanceIncomeTax_Schedule> Acc_AdvanceIncomeTax_Schedule { get; set; }

        public DbSet<Acc_GovtSchedule_Subsidy> Acc_GovtSchedule_Subsidy { get; set; }
        public DbSet<Acc_GovtSchedule_StoreInTransit> Acc_GovtSchedule_StoreInTransit { get; set; }

        //public DbSet<Acc_VoucherSubCheckno_Clearing> Acc_VoucherSubCheckno_Clearings { get; set; }

        //public DbSet<SubSection> SubSections { get; set; }
        public DbSet<Acc_VoucherType> Acc_VoucherTypes { get; set; }


        public DbSet<Acc_BudgetMain> Acc_BudgetMains { get; set; }
        public DbSet<Acc_BudgetSub> Acc_BudgetSubs { get; set; }
        public DbSet<Acc_BudgetSubSection> Acc_BudgetSubSections { get; set; }


        public DbSet<CurrencyTransaction> CurrencyTransactions { get; set; }

        ///////Technical
        ///

        public DbSet<Cat_Meeting> Cat_Meeting { get; set; }
        public DbSet<Technical> Technical { get; set; }

        //public DbSet<Cat_AuditYear> Cat_AuditYear { get; set; }
        //public DbSet<Cat_AuditType> Cat_AuditType { get; set; }

        //public DbSet<Cat_AuditObjType> Cat_AuditObjType { get; set; }
        //public DbSet<AuditInfo> AuditInfo { get; set; }
        //public DbSet<Cat_Meeting> Cat_Meeting { get; set; }

        //public DbSet<Cat_Training> Cat_Training { get; set; }
        //public DbSet<Cat_TrainingSub> Cat_TrainingSub { get; set; }
        //public DbSet<Cat_FireSafetyItem> Cat_FireSafetyItem { get; set; }
        //public DbSet<Cat_FireSafetyType> Cat_FireSafetyType { get; set; }
        //public DbSet<Cat_FireSafetyLocation> Cat_FireSafetyLocation { get; set; }        
        ////public DbSet<Cat_ImportAcidItem> Cat_ImportAcidItem { get; set; }
        //public DbSet<Cat_Inspection> Cat_Inspection { get; set; }
        //public DbSet<Cat_InspectionInst> Cat_InspectionInst { get; set; }
        //public DbSet<Cat_License> Cat_License { get; set; }
        //public DbSet<Cat_LicenseAuth> Cat_LicenseAuth { get; set; }
        //public DbSet<Cat_Waste> Cat_Waste { get; set; }
        //public DbSet<Tech_Meeting> Tech_Meeting { get; set; }
        //public DbSet<Tech_Training> Tech_Training { get; set; }
        //public DbSet<Tech_Inspection> Tech_Inspection { get; set; }
        //public DbSet<Tech_ImportAcid> Tech_ImportAcid { get; set; }
        //public DbSet<Tech_WasteMgt> Tech_WasteMgt { get; set; }
        //public DbSet<Tech_License> Tech_License { get; set; }
        //public DbSet<Tech_FireSafety> Tech_FireSafety { get; set; }


        ////////commercial module
        /// <summary>
        public DbSet<StyleInformation> StyleInformation { get; set; }
        public DbSet<BrandInfo> BrandInfo { get; set; }
        public DbSet<SisterConcernCompany> SisterConcernCompany { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<BuyerInformation> BuyerInformation { get; set; }
        public DbSet<NotifyParty> NotifyPartys { get; set; }
        public DbSet<ExportOrder> ExportOrders { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<UnitMaster> UnitMasters { get; set; }
        public DbSet<UnitGroup> UnitGroups { get; set; }
        public DbSet<SupplierInformation> SupplierInformations { get; set; }
        public DbSet<COM_CNFExpenseType> COM_CNFExpenseTypes { get; set; }
        public DbSet<COM_CNFBillImportMaster> COM_CNFBillImportMasters { get; set; }
        public DbSet<COM_CNFBillImportDetails> COM_CNFBillImportDetailss { get; set; }
        public DbSet<COM_CNFBillExportMaster> COM_CNFBillExportMasters { get; set; }
        public DbSet<COM_CNFBillExportDetails> COM_CNFBillExportDetails { get; set; }
        public DbSet<COM_MasterLCExport> COM_MasterLCExports { get; set; }
        public DbSet<COM_MasterLC_Details> COM_MasterLC_Detailss { get; set; }
        public DbSet<COM_MasterLC> COM_MasterLCs { get; set; }
        public DbSet<GTERP.Models.LienBank> LienBanks { get; set; }
        public DbSet<GTERP.Models.OpeningBank> OpeningBanks { get; set; }
        public DbSet<GTERP.Models.BankAccountNo> BankAccountNos { get; set; }
        public DbSet<GTERP.Models.BankAccountNoLienBank> BankAccountNoLienBanks { get; set; }
        public DbSet<GTERP.Models.PortOfLoading> PortOfLoadings { get; set; }
        public DbSet<GTERP.Models.PortOfDischarge> PortOfDischarges { get; set; }
        public DbSet<GTERP.Models.StyleStatus> StyleStatus { get; set; }
        public DbSet<GTERP.Models.ShipMode> ShipModes { get; set; }
        public DbSet<GTERP.Models.ExportOrderStatus> ExportOrderStatus { get; set; }
        public DbSet<GTERP.Models.ExportOrderCategory> ExportOrderCategorys { get; set; }
        public DbSet<GTERP.Models.LCNature> LCNatures { get; set; }
        public DbSet<GTERP.Models.LCType> LCTypes { get; set; }
        public DbSet<GTERP.Models.TradeTerm> TradeTerms { get; set; }
        public DbSet<GTERP.Models.LCStatus> LCStatus { get; set; }

        //public DbSet<PINature> PINature { get; set; }

        public DbSet<GTERP.Models.PaymentTerms> PaymentTerms { get; set; }
        public DbSet<GTERP.Models.DayList> DayLists { get; set; }
        public DbSet<GTERP.Models.StyleInformations_Temp> StyleInformations_Temps { get; set; }
        public DbSet<COM_GroupLC_Main> COM_GroupLC_Mains { get; set; }
        public DbSet<COM_GroupLC_Sub> COM_GroupLC_Subs { get; set; }
        public DbSet<Temp_COM_MasterLC_Detail> Temp_COM_MasterLC_Details { get; set; }
        public DbSet<Temp_COM_MasterLC_Master> Temp_COM_MasterLC_Masters { get; set; }
        public DbSet<Temp_COM_ProformaInvoice> Temp_COM_ProformaInvoices { get; set; }
        public DbSet<COM_ProformaInvoice> COM_ProformaInvoices { get; set; }
        public DbSet<COM_ProformaInvoice_Sub> COM_ProformaInvoice_Subs { get; set; }
        public DbSet<COM_CommercialInvoice> COM_CommercialInvoices { get; set; }

        public DbSet<COM_CommercialInvoice_Sub> COM_CommercialInvoice_Subs { get; set; }

        //public DbSet<COM_DocumentAcceptance> COM_DocumentAcceptances { get; set; }
        public DbSet<COM_BBLC_Master> COM_BBLC_Master { get; set; }
        public DbSet<COM_BBLC_Details> COM_BBLC_Details { get; set; }
        public DbSet<DocumentStatus> DocumentStatuss { get; set; }
        public DbSet<CommercialLCType> CommercialLCTypes { get; set; }
        public DbSet<ApprovedBy> ApprovedBys { get; set; }
        public DbSet<WorkorderStatus> WorkorderStatus { get; set; }
        public DbSet<WorkOrderMaster> WorkOrderMasters { get; set; }
        public DbSet<Consignee> Consignees { get; set; }
        public DbSet<COM_DocumentAcceptance_Master> COM_DocumentAcceptance_Masters { get; set; }
        public DbSet<COM_DocumentAcceptance_Details> COM_DocumentAcceptance_Details { get; set; }

        //public DbSet<Forwarder> Forwarders { get; set; }
        //public DbSet<Exporter> Exporters { get; set; }
        public DbSet<ExportInvoiceMaster> ExportInvoiceMasters { get; set; }
        public DbSet<ExportInvoiceDetails> ExportInvoiceDetailss { get; set; }
        public DbSet<ExportInvoicePackingList> ExportInvoicePackingLists { get; set; }
        public DbSet<ExportRealizationMaster> ExportRealizationMasters { get; set; }
        public DbSet<ExportRealizationDetails> ExportRealizationDetailss { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<SuccessLog> SuccessLogs { get; set; }
        public DbSet<UserTransactionLog> UserTransactionLogs { get; set; }
        public DbSet<UserLogingInfo> UserLogingInfos { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemDesc> ItemDescs { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        //public DbSet<ApprovedByHimu> ApprovedByHimus { get; set; }
        public DbSet<BuyerGroup> BuyerGroups { get; set; }
        //public DbSet<COM_MachineryLCMaster> COM_MachineryLCMasters { get; set; }
        //public DbSet<COM_MachineryLCDetails> COM_MachineryLCDetailses { get; set; }
        public DbSet<COM_MachinaryLC_Master> COM_MachinaryLC_Masters { get; set; }
        public DbSet<COM_MachinaryLC_Details> COM_MachinaryLC_Detailss { get; set; }
        public DbSet<ExportRealization_Master> ExportRealization_Masters { get; set; }
        public DbSet<ExportRealization_Details> ExportRealization_Detailss { get; set; }
        public DbSet<ImageCriteria> ImageCriterias { get; set; }
        //public DbSet<ExportRealizationBankInfo> ExportRealizationBankInfo { get; set; }
        public DbSet<GTERP.Models.Payroll.SalaryProcess> SalaryProcess { get; set; }
        public DbSet<Payroll_SalaryAddition> Payroll_SalaryAddition { get; set; }
        public DbSet<HR_PFContribution> HR_PFContribution { get; set; }

        //Approval
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<ApprovalPanel> ApprovalPanels { get; set; }
        public DbSet<ApprovalRole> ApprovalRoles { get; set; }

        //userStates
        public DbSet<UserState> UserStates { get; set; }

        //userStates
        public DbSet<GTERP.Models.StoreRequisitionMain> StoreRequisitionMain { get; set; }
        public DbSet<GTERP.Models.StoreRequisitionSub> StoreRequisitionSub { get; set; }

        //userStates
        public DbSet<GTERP.Models.IssueMain> IssueMain { get; set; }
        public DbSet<GTERP.Models.IssueSub> IssueSub { get; set; }
        public DbSet<GTERP.Models.IssueSubWarehouse> IssueSubWarehouse { get; set; }


        public DbSet<GTERP.Models.GatePass> GatePass { get; set; }
        public DbSet<GTERP.Models.GatePassSub> GatePassSub { get; set; }
        public DbSet<GTERP.Models.Asset> Asset { get; set; }
        public DbSet<GTERP.Models.Production> Production { get; set; }
        public DbSet<GTERP.Models.PurchaseType> PurchaseTypes { get; set; }
        public DbSet<GTERP.Models.Depreciation> Depreciations { get; set; }
        public DbSet<GTERP.Models.DepreciationMethod> DepreciationMethods { get; set; }
        public DbSet<GTERP.Models.ProductType> ProductTypes { get; set; }
        public DbSet<GTERP.Models.AssetCurrentState> assetCurrentStates { get; set; }
        public DbSet<GTERP.Models.DepreciationFrequency> depreciationFrequencies { get; set; }


        public DbSet<GTERP.Models.FA_Calculation> FA_Calculation { get; set; }
        public DbSet<GTERP.Models.FA_Sell> fA_Sells { get; set; }
        public DbSet<GTERP.Models.FA_Master> fA_Masters { get; set; }
        public DbSet<GTERP.Models.FA_Details> FA_Details { get; set; }
        public DbSet<GTERP.Models.FA_Dep_Status> fA_Dep_Statuses { get; set; }
        public DbSet<GTERP.Models.FA_ProcessRecord> FA_ProcessRecords { get; set; }
        public DbSet<GTERP.Models.DepreciationSchedule> DepreciationSchedules { get; set; }
        public DbSet<GTERP.Models.DepreciationScheduleSales> DepreciationScheduleSales { get; set; }
        public DbSet<GTERP.Models.TemDepSchedule> TemDepSchedules { get; set; }
        public DbSet<GTERP.Models.TemDepScheduleSale> TemDepScheduleSales { get; set; }
        public DbSet<GTERP.Models.Tem_FA_Details> Tem_FA_Details { get; set; }
        public DbSet<GTERP.Models.Tem_FA_Sell> Tem_FA_Sell { get; set; }



        ////budget related dbset // by fahad 12-dec-2020

        public DbSet<GTERP.Models.Budget_ProductionTarget> Budget_ProductionTargets { get; set; }


        public DbSet<GTERP.Models.PF_Ledger> PF_Ledgers { get; set; }
        public DbSet<GTERP.Models.WF_Ledger> WF_Ledgers { get; set; }
        public DbSet<GTERP.Models.Gratuity_Ledger> Gratuity_Ledgers { get; set; }
        public DbSet<GTERP.Models.Cat_ITInvestmentItem> Cat_ITInvestmentItem { get; set; }


        //public DbSet<AttachmentMain> AttachmentMains { get; set; }
        //public DbSet<AttachmentSub> AttachmentSubs { get; set; }

        /// 
        /// </Buffer
        /// 

        public virtual DbSet<BufferList> Buffers { get; set; }
        public virtual DbSet<BufferRepresentative> BuferRepresentative { get; set; }
        public virtual DbSet<BufferRepresentativeMember> BufferRepresentativeMember { get; set; }

        public virtual DbSet<RepresentativeBuffer> RepresentativeBuffers { get; set; }
        public virtual DbSet<DistictBuffer> BufferDisticts { get; set; }
        public virtual DbSet<BuffertWiseBooking> BuffertWiseBookings { get; set; }
        public virtual DbSet<RepresentativeBooking> RepresentativeBooking { get; set; }
        public virtual DbSet<BufferDelOrder> BufferDelOrder { get; set; }
        public virtual DbSet<BufferDelChallan> BufferDelChallan { get; set; }
        public virtual DbSet<BufferGatePass> BufferGatePass { get; set; }
        public virtual DbSet<BufferGatePassSub> BufferGatePassSub { get; set; }
        public virtual DbSet<ReceivedFromBufferBankAmountsModels> ReceivedFromBufferBankAmountsModels { get; set; }
        public virtual DbSet<BanksModel> BanksModel { get; set; }
        public virtual DbSet<BufferSaleReportInput> BufferSaleReportInputs { get; set; }
        public virtual DbSet<SalesOpening> SalesOpeningBalances { get; set; }
        public virtual DbSet<FactoryInfomation> FactoryInfos { get; set; }
        public virtual DbSet<BufferFactoryInfomation> BufferFactoryInfomations { get; set; }
        public virtual DbSet<BufferAllotment_MOA> BufferAllotment_MOA { get; set; }





    }

}



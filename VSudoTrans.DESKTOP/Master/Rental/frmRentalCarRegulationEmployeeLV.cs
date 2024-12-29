using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Rental;
using PopUpUtils;
using System;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Rental
{
    public partial class frmRentalCarRegulationEmployeeLV : frmBaseFilterLV
    {
        public frmRentalCarRegulationEmployeeLV()
        {
            InitializeComponent();

            EndPoint = "/RentalCarRegulationEmployees";
            FormTitle = "Peraturan Komisi Karyawan";

            OdataSelect = "Id,StartDate,EndDate";
            OdataExpand = "Company($select=name)";
            OdataExpand += ",RentalCarRegulationEmployeeDetails($select=Type,Amount)";

            InitializeComponentAfter<RentalCarRegulationEmployee>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;

            _GridView.OptionsView.ShowDetailButtons = true;
            _GridView.OptionsDetail.EnableMasterViewMode = true;
            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            _GridViewDetail.OptionsView.ShowFooter = true;
            _GridViewDetail.ViewCaption = "Detail";
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);

            GridHelper.GridColumnInitializeLayout(colStartDate, typeof(DateTime), "dd-MMM-yyyy");
            GridHelper.GridColumnInitializeLayout(colEndDate, typeof(DateTime), "dd-MMM-yyyy");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<RentalCarRegulationEmployee>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<RentalCarRegulationEmployee>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmRentalCarRegulationEmployeeDV(EntityId, EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }
    }
}

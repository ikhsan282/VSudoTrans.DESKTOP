using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Travel;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSudoTrans.DESKTOP.Report.Travel
{
    public partial class frmTripSchedulePV : frmBasePV
    {
        public frmTripSchedulePV()
        {
            InitializeComponent();

            this.EndPoint = "/TripSchedules";
            this.FormTitle = "Laporan Data Surat Perintah Jalan (SPJ)";

            this.OdataSelect = "Id,Date,StartTime,EndTime";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",Employee($select=Name)";
            this.OdataExpand += ",PickupPointCity($select=Name)";
            this.OdataExpand += ",DeliveryPointCity($select=Name)";
            //this.OdataExpand += ",TripScheduleDetails($select=LineNumberPickup,LineNumberDelivery;$expand=TravelTicketBooking($select=Time,PickupAddress,PickupPointCityId,DeliveryPointCityId,DeliveryAddress,Status,PaymentType,TotalTicket,TotalPrice))";
            this.OdataExpand += ",Vehicle($select=VehicleNumber;$expand=Brand($select=name),ModelUnit($select=name))";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<TripSchedule>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Akhir";

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>()
        {
            this.OdataFilter = $"Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")}";

            if (FilterPopUp3.EditValue != null)
                OdataFilter += $" and CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<TripSchedule>();
        }
    }
}

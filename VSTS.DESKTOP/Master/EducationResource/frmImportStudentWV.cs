using System;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Master.EducationResource
{
    public partial class frmImportStudentWV : frmBaseImportWV
    {
        public frmImportStudentWV()
        {
            InitializeComponent();

            this.Text = "Import Murid";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();

            GridHelper.GridColumnInitializeLayout(colJoinDate, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colEndDate, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colBirthDate, typeof(DateTime));
        }
    }
}

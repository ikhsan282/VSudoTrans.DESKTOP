﻿using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.EducationResource
{
    public partial class frmImportClassWV : frmBaseImportWV
    {
        public frmImportClassWV()
        {
            InitializeComponent();

            this.Text = "Import Kelas";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

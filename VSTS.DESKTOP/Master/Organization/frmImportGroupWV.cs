﻿using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Organization
{
    public partial class frmImportGroupWV : frmBaseImportWV
    {
        public frmImportGroupWV()
        {
            InitializeComponent();

            this.Text = "Import Yayasan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

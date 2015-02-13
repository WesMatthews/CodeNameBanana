/*
* ++++++++++++++++++++++++++++++++++++++++++++++++++
* This code is generated by a tool and is provided "as is", without warranty of any kind,
* express or implied, including but not limited to the warranties of merchantability,
* fitness for a particular purpose and non-infringement.
* In no event shall the authors or copyright holders be liable for any claim, damages or
* other liability, whether in an action of contract, tort or otherwise, arising from,
* out of or in connection with the software or the use or other dealings in the software.
* ++++++++++++++++++++++++++++++++++++++++++++++++++
* */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Objects;

namespace ppSoft_MySql
{
	public partial class frmaccess_level : Form
	{
		private Model1Entities ctx;
		
		public frmaccess_level()
		{
			InitializeComponent();
		}
		
		private void frmaccess_level_Load(object sender, EventArgs e)
		{
			ctx = new Model1Entities();
			ObjectResult<access_level> _entities = ctx.access_level.Execute(MergeOption.AppendOnly);
			access_levelBindingSource.DataSource = _entities;
			this.access_levelIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.access_levelBindingSource, "access_levelID", true ));
			this.accessTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.access_levelBindingSource, "access", true ));
			
		}
		
		private void Save_Click(object sender, EventArgs e)
		{
			if (!this.Validate()) return;
			access_levelBindingSource.EndEdit();
			ctx.SaveChanges();
			
		}
		
		private void frmaccess_level_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
		}
		
		private void access_levelIDTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( access_levelIDTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( access_levelIDTextBox, "The field access_levelID is required" ); 
			}
			int v;
			string s = access_levelIDTextBox.Text;
			if( !int.TryParse( s, out v ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( access_levelIDTextBox, "The field access_levelID must be int." );
			}
			if( !e.Cancel ) { errorProvider1.SetError( access_levelIDTextBox, "" ); } 
		}
		
		private void accessTextBox_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
			if( string.IsNullOrEmpty( accessTextBox.Text ) )
			{
				e.Cancel = true;
				errorProvider1.SetError( accessTextBox, "The field access is required" ); 
			}
			if( !e.Cancel ) { errorProvider1.SetError( accessTextBox, "" ); } 
		}
		
		
		
		
		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			access_levelBindingSource.AddNew();
		}
	}
}
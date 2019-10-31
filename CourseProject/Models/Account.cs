using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject.Models
{
    public class Account
    {
        public int AccId { get; set; }

        public int Summa { get; set; }

        private bool IsPrivate = default;

        static SemaphoreSlim semaphore1 = new SemaphoreSlim(1, 1);
        static SemaphoreSlim semaphore2 = new SemaphoreSlim(1, 1);

        public async Task<bool> PutCash(int sum)
        {
            //MessageBox.Show("Putting cash on Operational Account", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            await semaphore1.WaitAsync();
            try
            {
                await Task.Run(()=> { Summa += sum; });
                return true;
            }
            finally
            {
                semaphore1.Release();
            }
          
        }

        public async Task<bool> GetCash(int sum)
        {
            
            await semaphore2.WaitAsync();
           
            try
            {
                return await Task.Run(() => 
                {
                    if (!IsPrivate)
                    {
                        DialogResult result = MessageBox.Show("Taking cash from Operational Account. Press OK to allow or Cancel to abort operation", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Cancel) { return false; }
                    }
                    if ((Summa - sum) > 0) { Summa -= sum; return true; }
                    else { return false; }
                });
            }
            finally
            {
                semaphore2.Release();
            }
            
        }

        public void SetPrivacy()
        {
            IsPrivate = true;
        }
    }
}

using System;
using System.IO;

namespace airNZ_reportNum {
    class ReportNumber {
        private string dir;
        private string year;
        private char month;

        public ReportNumber(string dir) {
            this.dir = dir;

            DateTime dt = DateTime.Now;
            this.year = dt.Year.ToString().Remove(0, 2);
            this.month = (char)(dt.Month + 64);
        }

        private string calculateReportNumber(string sDir, string r = null) {
            if (r == null) r = year + month + "000";
            try {
                foreach (string d in Directory.GetDirectories(sDir)) {
                    r = calculateReportNumber(d, r);
                }
                foreach (string f in Directory.GetFiles(sDir)) {
                    string fname = Path.GetFileName(f);
                    if (fname.Remove(2) == this.year) {
                        int fileNum = int.Parse(fname.Split('.')[0].Remove(0,3));
                        int num = int.Parse(r.Remove(0,3));
                        if (fileNum >= num) r = r.Remove(3) + (fileNum + 1).ToString("D3");
                    }
                }
            }
            catch (System.Exception e) {
                throw e;
            }
            return r;
        }

        public override string ToString()
        {
            try {
                return calculateReportNumber(dir);
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}
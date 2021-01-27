using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heima8.OA.UI.Portal.Models
{
    public class DailyWorkViewModel
    {
        public int Id { get; set; }
        public string WorkName { get; set; }
        public string WorkContent { get; set; }
        public string SqlLog { get; set; }
        public string DeptName { get; set; }
        public string Remark { get; set; }
        public string UName { get; set; }
        public DateTime? SubTime { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class DailyWorkViewModels:IEnumerable
    {
        private DailyWorkViewModel[] _dailyWorkViewModels;
        public DailyWorkViewModels(DailyWorkViewModel[] mDailyWorkViewModel)
        {
            _dailyWorkViewModels = new DailyWorkViewModel[mDailyWorkViewModel.Length];
            for (int i = 0; i < mDailyWorkViewModel.Length; i++)
            {
                _dailyWorkViewModels[i] = mDailyWorkViewModel[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private IEnumerator GetEnumerator()
        {
            return new DailyWorkViewModelEnum(_dailyWorkViewModels);
        }
    }

    public class DailyWorkViewModelEnum: IEnumerator
    {
        public DailyWorkViewModel[] _dailyWorkViewModel;

        int position = -1;
        public DailyWorkViewModelEnum(DailyWorkViewModel[] list)
        {
            _dailyWorkViewModel = list;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _dailyWorkViewModel[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public Boolean MoveNext()
        {
            position++;
            return position < _dailyWorkViewModel.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
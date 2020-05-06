using System;
using System.Collections.Generic;
using System.Text;

namespace Vemic.Trackall.AzureFunctions.Core.Idm
{
    public class Idm
    {
        /// <summary>
        /// ユーザを識別するIDです。
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// IDMを識別するIDです。
        /// </summary>
        public string IdmID { get; set; }

        /// <summary>
        /// IDMのタイトルです。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// IDMの説明です。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 予定の開始日です。
        /// </summary>
        public DateTime ScheduledStartDateTime { get; set; }

        /// <summary>
        /// 予定の終了日です。
        /// </summary>
        public DateTime ScheduledEndDateTime { get; set; }

        /// <summary>
        /// 実績の開始日です。
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 実績の終了日です。
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// ヘッダ情報に含まれない詳細情報です。
        /// </summary>
        public object DetailInfo { get; set; }
    }
}

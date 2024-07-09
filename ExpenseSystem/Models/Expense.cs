namespace ExpenseSystem.Models
{
    public class Expense
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 金額
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 初始化 <see cref="Expense"/> 類的新實例
        /// </summary>
        public Expense() { }

        /// <summary>
        /// 初始化 <see cref="Expense"/> 類的新實例
        /// </summary>
        /// <param name="id">序號</param>
        /// <param name="title">名稱</param>
        /// <param name="amount">金額</param>
        /// <param name="date">日期</param>
        /// <param name="category">類別</param>
        public Expense(int id, string title, decimal amount, DateTime date, string category)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Date = date;
            Category = category;
        }
    }
}

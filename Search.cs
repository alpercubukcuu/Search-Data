public List<ViewFilter> GetSearchProducts(string s)
        {
            string[] search = s.Split(' ');
            var query = "select * from  [dbo].[ViewFilter] where  ";

            foreach(var item in search)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    query += "SearchTerm like '%" + item + "%' and ";
                }
            }
            query = query.Substring(0, query.Length - 4);

            List<ViewFilter> viewFilters = _db.ViewFilter.FromSqlRaw(query).ToList().GroupBy(m => new { m.Id }).Select(p => p.First()).Distinct().ToList();
           
            return viewFilters;

        }

namespace Warehouse.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Warehouse.Api.WarehouseContext;

    public class Helper
    {
        private static Helper _instance;
        public static Helper Instance
        {
            get { if (_instance == null) _instance = new Helper(); return _instance; }
        }

        public void SetAudit(dynamic model)
        {
            if (model != null)
            {
                using (var db = new WarehouseContext())
                {
                    User user = db.Users.FirstOrDefault();

                    Type to = ((object)model).GetType();

                    string typeName = to.Name + "Id";

                    int id = to.GetProperty(typeName).GetValue(model, null);

                    if (id == 0)
                    {

                        int last = db.Sequences.OrderByDescending(x => x.SequenceId).Select(x => x.SequenceId).FirstOrDefault();
                        Sequence seq = db.Sequences.FirstOrDefault(x => x.entityname == to.Name);
                        if (seq == null)
                        {
                            seq = new Sequence { SequenceId = last != 0 ? last + 1 : 1, entityname = to.Name, seq = 1 };
                            db.Sequences.Add(seq);
                        }
                        else
                        {
                            seq.seq = seq.seq + 1;
                            db.Sequences.Update(seq);
                        }
                        db.SaveChanges();

                        to.GetProperty(typeName).SetValue(model, seq.seq, null);

                        if (string.IsNullOrWhiteSpace(model.code))
                        {
                            model.code = $"{to.Name.First()}_{seq.seq}";
                        }


                        model.createdDate = DateTime.Now;
                        if (to.GetProperty("createdUserId") != null)
                        {
                            model.createdUserId = (user != null ? (int?)user.UserId : null);
                        }

                        model.lastUpdatedDate = DateTime.Now;
                        if (to.GetProperty("createdUserId") != null)
                        {
                            model.lastUpdatedUserId = (user != null ? (int?)user.UserId : null);
                        }
                    }
                    else
                    {
                        model.lastUpdatedDate = DateTime.Now;
                        if (to.GetProperty("createdUserId") != null)
                        {
                            model.lastUpdatedUserId = (user != null ? (int?)user.UserId : null);
                        }
                    }
                }
            }
        }
    }
}

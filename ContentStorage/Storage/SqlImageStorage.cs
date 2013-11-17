using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContentStorage.Contract;

namespace ContentStorage.Storage
{
    internal class SqlImageStorage : BaseImageStorage
    {
        public override IImageSource Save(byte[] image, string extension = "", string path = "")
        {
            throw new NotImplementedException();
        }

        public override bool Delete(string source)
        {
            throw new NotImplementedException();
        }

        public override byte[] Retrieve(string source)
        {
            throw new NotImplementedException();
        }
    }
}

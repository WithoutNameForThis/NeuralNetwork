using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 神经网络
{
    [Serializable]
    class arrayRaw
    {
        public double[] Data;
    }


    class ObjectSaver<T> where T:new()
    {
        /// <summary>
        /// 读取播放列表组于文件中。
        /// </summary>
        public static T loadByFile(string name)
        {
            FileStream fs = new FileStream(
                Application.StartupPath + string.Format(@"/Data/{0}.dat",name), FileMode.Open);
            long size = fs.Length;
            byte[] array = new byte[size];
            fs.Read(array, 0, array.Length);



            fs.Close();
            return  load(array);
        }
        /// <summary>
        /// 保存播放列表组于文件中。
        /// </summary>
        public static void saveToLocal(T obj ,string name)
        {
            FileStream fs = new FileStream(
                Application.StartupPath +string.Format( @"/Data/{0}.dat",name), FileMode.Create);
            byte[] array = save(obj);
            fs.Write(array, 0, array.Length);


            fs.Close();
        }

        /// <summary>
        /// 将序列化的播放列表组反序列化。
        /// </summary>
        /// <param name="bytes">序列化的播放列表组的对象。</param>
        public static T load(byte[] bytes)
        {
            object obj = null;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();


            T temp;
            try
            {

                obj = formatter.Deserialize(ms);


                temp = (T)obj;
            }
            catch
            {
                MessageBox.Show("unExp");
                temp = default(T);
            }
            ms.Close();
            return temp;

        }
        public static byte[] save(T a)
        {
            T obj = a;
            if (obj == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

    }
}

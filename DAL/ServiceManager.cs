using System;
using DAL;
using System.Collections.Generic;

namespace DAL.DotNetService{
	public class ServiceManager 
    {

		public ServiceManager() {

		}

		private static ServiceManager instance = null;
		private static object locker = new Object();

		public static ServiceManager Instance {
			get {
				if (instance == null) {
					lock (locker) {
						if (instance == null) {
							instance = new ServiceManager();
						}
					}
				}
				return instance;
			}
		}


        public UserInfo UserInfo
        {
            get {
                return new UserInfo();
            }
        }

        public Admin Admin
        {
            get
            {
                return new Admin();
            }
        }


        private static string _seed1 = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789";  //length: 34

        private static string _seed2 = "0123456789";  //length: 10

        private static Random _random = new Random();

        public static string CreateRandomCode(int length, bool withChar)
        {
            string seed = "";
            if (withChar)
            {
                seed = _seed1;
            }
            else
            {
                seed = _seed2;
            }
            char[] ss = new char[length];
            for (int i = 0; i < length; i++)
            {
                int m = _random.Next(seed.Length);
                ss[i] = seed[m];
            }
            return new string(ss);
        }
	}
}

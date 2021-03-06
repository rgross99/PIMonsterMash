﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PIMonsterMash {
    static class MusicPlayer {
        static Dictionary<int, string> musicList = new Dictionary<int, string>();
        static SoundPlayer soundDevice;

        static MusicPlayer() {
            musicList.Add(0, AppDomain.CurrentDomain.BaseDirectory + "\\Forest.wav");
        }

        public static string GetRandom() {
            var rnd = new Random(DateTime.Now.Millisecond);
            return musicList[rnd.Next(0, musicList.Count)];
        }

        public static void Play(string path) {  
            if (!String.IsNullOrEmpty(path)) {
                soundDevice = new SoundPlayer();
                soundDevice.SoundLocation = path;
                soundDevice.PlayLooping();
            }
        }

        public static void Stop() {
            if (soundDevice != null) {
                soundDevice.Stop();
            }
        }
    }
}

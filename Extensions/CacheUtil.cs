using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ff_platform.NFL_API;
using ff_platform.NFL_API.Models;
using Newtonsoft.Json;

namespace ff_platform.Extensions
{
    public class CacheUtil
    {
        public static CacheUtil Instance { get; set; }

        StatsCache _stats { get; set; }
        PlayerIDNameCache _playerIDNames { get; set; }

        static ReaderWriter _readerWriter { get; set; }
        static string _serialize(object obj) => Serializer.Serialize(obj);
        static T _deserialize<T>(string content) => Deserializer.FromJson<T>(content);


        public CacheUtil()
        {
            _stats = new StatsCache();
        }

        public static void Initialize()
        {
            Instance = new CacheUtil();
        }

        public class ReaderWriter
        {
            static ReaderWriter _instance { get; set; }

            string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "CacheUtil");


            public ReaderWriter()
            {
                _instance = this;

                if (!Directory.Exists(rootPath))
                {
                    Directory.CreateDirectory(rootPath);
                }
            }

            public static string Read(string cache)
            {
                var path = Path.Combine(_instance.rootPath, cache);

                if (!File.Exists(path))
                {
                    return string.Empty;
                }

                return File.ReadAllText(path);
            }

            public static void Write(string cache, string content)
            {
                var path = Path.Combine(_instance.rootPath, cache);

                File.WriteAllText(path, content);
            }
        }

        public static class PlayerSeasonStats
        {
            static string _root = "PlayerSeasonStats";

            public static List<PlayerSeasonStatsModel> GetBySeason(int year)
            {
                // TODO: Allow parameter for playerIDs to not always return all
                var content = Path.Combine(_root, year.ToString());

                return Deserializer.FromJson<List<PlayerSeasonStatsModel>>(content);
            }
        }
    }


    public class StatsCache
    {
        static List<StatModel> _statsList { get; set; }

        static object _lock { get; set; }


        public StatsCache()
        {
            _statsList = new List<StatModel>();
        }

        public static List<StatModel> GetAllStatsCache()
        {
            return _statsList;
        }

        public static void SetAllStatsCache(List<StatModel> stats)
        {
            _statsList = stats;
        }
    }

    public class PlayerIDNameCache
    {
        static Dictionary<int, string> _cache { get; set; }
        static object _lock { get; set; }
        static string _fileName = "playeridname";


        public PlayerIDNameCache()
        {
            _cache = new Dictionary<int, string>();
        }

        Dictionary<int, string> ReadCache()
        {
            var cache = new Dictionary<int, string>();

            var content = CacheUtil.ReaderWriter.Read(_fileName);

            if (!string.IsNullOrEmpty(content))
            {
                cache = Deserializer.FromJson<Dictionary<int, string>>(content);
            }

            return cache;
        }

        void Update(int playerID, string name)
        {
            lock (_lock)
            {
                _cache = ReadCache();

                _cache.TryGetValue(playerID, out var playerName);

                if (string.IsNullOrEmpty(playerName))
                {
                    _cache.Add(playerID, name);
                }
                else
                {
                    _cache[playerID] = name;
                }

                CacheUtil.ReaderWriter.Write(_fileName, Serializer.Serialize(_cache));
            }
        }
    }
}

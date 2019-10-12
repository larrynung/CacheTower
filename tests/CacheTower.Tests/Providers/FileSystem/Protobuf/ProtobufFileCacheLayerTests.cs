﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheTower.Providers.FileSystem.Protobuf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CacheTower.Tests.Providers.FileSystem.Protobuf
{
	[TestClass]
	public class ProtobufFileCacheLayerTests : BaseCacheLayerTests
	{
		public const string DirectoryPath = "FileSystemProviders/ProtobufFileCacheLayer";

		[AssemblyInitialize]
		public static void AssemblySetup(TestContext testContext)
		{
			ProtobufFileCacheLayer.ConfigureProtobuf();
		}

		[TestInitialize]
		public void Setup()
		{
			if (Directory.Exists(DirectoryPath))
			{
				Directory.Delete(DirectoryPath, true);
			}

			Directory.CreateDirectory(DirectoryPath);
		}

		[TestMethod]
		public async Task GetSetCache()
		{
			using (var cacheLayer = new ProtobufFileCacheLayer(DirectoryPath))
			{
				await AssertGetSetCache(cacheLayer);
			}
		}

		[TestMethod]
		public async Task IsCacheAvailable()
		{
			using (var cacheLayer = new ProtobufFileCacheLayer(DirectoryPath))
			{
				await AssertCacheAvailability(cacheLayer, true);
			}
		}

		[TestMethod]
		public async Task EvictFromCache()
		{
			using (var cacheLayer = new ProtobufFileCacheLayer(DirectoryPath))
			{
				await AssertCacheEviction(cacheLayer);
			}
		}

		[TestMethod]
		public async Task CacheCleanup()
		{
			using (var cacheLayer = new ProtobufFileCacheLayer(DirectoryPath))
			{
				await AssertCacheCleanup(cacheLayer);
			}
		}
	}
}

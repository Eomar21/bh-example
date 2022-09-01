using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace DataImporter.Services.NUnit
{
    public class Tests
    {
        private IFileProcessorService? m_FileProcessorService;
        private IVolumeProcessorService? m_VolumeProcessorService;
        private static readonly string m_FileTemplate = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString(), @"Resources\data2x2.csv");

        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            services.WithCoreServices();
            services.BuildServiceProvider();
            m_VolumeProcessorService = services.BuildServiceProvider().GetService<IVolumeProcessorService>();
            m_FileProcessorService = services.BuildServiceProvider().GetService<IFileProcessorService>();
        }

        [Test]
        public void CheckIfVolumeIsAsExpected()
        {
            ProcessedData? data = m_FileProcessorService.ReadAndProcess(m_FileTemplate, 5, 5, 10, 10);
            Assert.That(data, Is.Not.Null);
            double volume = m_VolumeProcessorService.GetVolume(data.Data);
            Assert.That(volume, Is.EqualTo(2000));
            Assert.That(m_VolumeProcessorService.GetVolumeAboveFluidContact(data.Data, 5), Is.EqualTo(1000));
        }

        [Test]
        public void CheckThatInlineAndCrossLineCountIsCorrect()
        {
            ProcessedData? data = m_FileProcessorService.ReadAndProcess(m_FileTemplate, 5, 5, 10, 10);
            Assert.That(data, Is.Not.Null);
            Assert.That(data.InLineCount, Is.EqualTo(2));
            Assert.That(data.CrossLineCount, Is.EqualTo(2));
        }
    }
}
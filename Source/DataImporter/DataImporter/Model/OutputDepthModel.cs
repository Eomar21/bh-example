using System;

namespace DataImporter.Model
{
    internal class OutputDepthModel : BaseObserver
    {
        private int m_InlineNodeCount;
        private int m_CrossLineNodeCount;
        private double m_Volume;
        private double m_VolumeMeter;
        private double m_VolumeUSBarrel;

        public int CrossLineNodeCount
        {
            get => m_CrossLineNodeCount;
            set
            {
                m_CrossLineNodeCount = value;
                NotifyPropertyChanged();
            }
        }

        public int InlineNodeCount
        {
            get => m_InlineNodeCount;
            set
            {
                m_InlineNodeCount = value;
                NotifyPropertyChanged();
            }
        }

        public double Volume
        {
            get => m_Volume;
            set
            {
                m_Volume = Math.Round(value, 2);
                VolumeMeter = Math.Round(value / 3.2808, 2);
                VolumeUSBarrel = Math.Round(value * 0.17811, 2);
                NotifyPropertyChanged();
            }
        }

        public double VolumeMeter
        {
            get
            {
                return m_VolumeMeter;
            }
            set
            {
                m_VolumeMeter = value;
                NotifyPropertyChanged();
            }
        }

        public double VolumeUSBarrel
        {
            get
            {
                return m_VolumeUSBarrel;
            }
            set
            {
                m_VolumeUSBarrel = value;
                NotifyPropertyChanged();
            }
        }
    }
}
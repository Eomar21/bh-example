namespace DataImporter.Model
{
    internal class OutputDepthModel : BaseObserver
    {
        private int m_InlineNodeCount;
        private int m_CrossLineNodeCount;


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
    }
}

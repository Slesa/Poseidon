namespace Devices
{
    public interface IDisplay : IDevice
    {
        void Clear();
        void Display(string text);
    }

/*
		enum CapBlinks
        {
            blinkNone = 0                       //!< Kann nicht blinken
        , blinkAll = 1                      //!< Kann nur alles auf einmal blinken
        , blinkEach = 2                     //!< Jedes einzelne Zeichen kann blinken oder nicht
        };
		bool canBitmap() const
    int canBlink() const
bool canBlinkRate() const
		{
			return getValue(capBlinkRate, FALSE);
		}
		bool canBrightness() const
		{
			return getValue(capBrightness, FALSE);
		}
		void clear();
void home();
void setPosition(int x, int y);
void display(const QString& text);
void bitmap(const QString& bmp);
		int getColumns() const
		{
			return m_Columns;
		}
		int getRows() const
		{
			return m_Rows;
		}
		int getMaxX() const
		{
			return m_MaxX;
		}
		int getMaxY() const
		{
			return m_MaxY;
		}
protected slots:
		void onSaver();
protected:
		void resetTimer();
protected:
		int m_Columns;
int m_Rows;           
int m_MaxX;           
int m_MaxY;           
                                    
QString m_Saver;                    
QString m_SaverBmp;                 
int m_SaverDelay;                  
QTimer* m_Timer;                   
TSubstitution m_Substs;				
	};
}
*/
}

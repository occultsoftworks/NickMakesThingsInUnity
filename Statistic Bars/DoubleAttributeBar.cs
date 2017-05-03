/// <summary>
/// Double attribute bar.
/// </summary>
[System.Serializable]
public class DoubleAttributeBar {
	public double current, max;
	/// <summary>
	/// Gets the current percentage of the Statistic.
	/// </summary>
	/// <returns>The current percentage.</returns>
	public float GetCurrentPercentage(){
		return ((float)(current / max));
	}
	/// <summary>
	/// Gets the current value of the Statistic.
	/// </summary>
	/// <returns>The current.</returns>
	public double GetCurrent(){
		return current;
	}
	/// <summary>
	/// Gets the maximum value of the Statistic.
	/// </summary>
	/// <returns>The maximum.</returns>
	public double GetMaximum(){
		return max;
	}
	/// <summary>
	/// Returns a string that represents the current Attribute in Human Readable Form.
	/// </summary>
	/// <returns>A string that represents the current object.</returns>
	/// <filterpriority>2</filterpriority>
	public override string ToString (){
		return string.Format (""+current+" out of "+max);
	}
}
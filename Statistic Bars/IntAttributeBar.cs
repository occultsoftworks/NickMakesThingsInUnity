/// <summary>
/// Int attribute bar.
/// </summary>
[System.Serializable]
public class IntAttributeBar {
	public int current, max;
	/// <summary>
	/// Gets the current percentage of the Statistic.
	/// </summary>
	/// <returns>The current percentage.</returns>
	public float GetCurrentPercentage(){
		return (current / max);
	}
	/// <summary>
	/// Gets the current value of the Statistic.
	/// </summary>
	/// <returns>The current.</returns>
	public int GetCurrent(){
		return current;
	}
	/// <summary>
	/// Gets the maximum value of the Statistic.
	/// </summary>
	/// <returns>The maximum.</returns>
	public int GetMaximum(){
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
using System;

[Serializable]
public class LastComment
{
	public string _id ;
	public string target ;
	public Payload payload ;
	public User user ;
	public string targetId ;
	public DateTime created ;
	public int created_ts ;
	public bool notSafe ;
}

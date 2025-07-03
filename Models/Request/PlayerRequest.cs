namespace Models.Request;

public record PlayerRequest(string name,Enum.Clan Clan,int disk);

public record PlayerRequestName(string name);
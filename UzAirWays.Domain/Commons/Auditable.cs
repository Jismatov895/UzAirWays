﻿namespace UzAirWays.Domain.Commons;
public class Auditable
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt {  get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAtv { get; set; }
}

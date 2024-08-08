﻿namespace InvenTrackCore.Application.Dtos.Inventory.Response;

public class InventoryResponseDto
{
    public int InventoryId { get; set; }
    public string Code { get; set; } = null!;
    public string Active { get; set; } = null!;
    public int EquipmentTypeId { get; set; }
    public string EquipmentTypeName { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Series { get; set; } = null!;
    public string Model { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Details { get; set; }
    public string? Image { get; set; }
    public DateTime AuditCreateDate { get; set; }
    public int State { get; set; }
    public string StateInventory { get; set; } = null!;
}
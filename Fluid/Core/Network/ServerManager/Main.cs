using Fluid.Core.Logger;
using Fluid.Core.Network.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Fluid.Core
{
    public class Main
    {

        private DataPack[] PacketPool { get; set; }

        public void RegisterPacket(byte id, DataPack pack)
        {
            PacketPool[id & 0xff] = pack;
        }

        public void RegisterPackets()
        {
            PacketPool = new DataPack[256];
            RegisterPacket(ProtocolInfo.ADD_ENTITY_PACKET, AddEntityPacket.class);
            RegisterPacket(ProtocolInfo.ADD_ITEM_ENTITY_PACKET, AddItemEntityPacket.class);
            RegisterPacket(ProtocolInfo.ADD_PAINTING_PACKET, AddPaintingPacket.class);
            RegisterPacket(ProtocolInfo.ADD_PLAYER_PACKET, AddPlayerPacket.class);
            RegisterPacket(ProtocolInfo.ADVENTURE_SETTINGS_PACKET, AdventureSettingsPacket.class);
            RegisterPacket(ProtocolInfo.ANIMATE_PACKET, AnimatePacket.class);
            RegisterPacket(ProtocolInfo.AVAILABLE_COMMANDS_PACKET, AvailableCommandsPacket.class);
            RegisterPacket(ProtocolInfo.BATCH_PACKET, BatchPacket.class);
            RegisterPacket(ProtocolInfo.BLOCK_ENTITY_DATA_PACKET, BlockEntityDataPacket.class);
            RegisterPacket(ProtocolInfo.BLOCK_EVENT_PACKET, BlockEventPacket.class);
            RegisterPacket(ProtocolInfo.BLOCK_PICK_REQUEST_PACKET, BlockPickRequestPacket.class);
            RegisterPacket(ProtocolInfo.BOSS_EVENT_PACKET, BossEventPacket.class);
            RegisterPacket(ProtocolInfo.CHANGE_DIMENSION_PACKET, ChangeDimensionPacket.class);
            RegisterPacket(ProtocolInfo.CHUNK_RADIUS_UPDATED_PACKET, ChunkRadiusUpdatedPacket.class);
            RegisterPacket(ProtocolInfo.CLIENTBOUND_MAP_ITEM_DATA_PACKET, ClientboundMapItemDataPacket.class);
            RegisterPacket(ProtocolInfo.COMMAND_REQUEST_PACKET, CommandRequestPacket.class);
            RegisterPacket(ProtocolInfo.CONTAINER_CLOSE_PACKET, ContainerClosePacket.class);
            RegisterPacket(ProtocolInfo.CONTAINER_OPEN_PACKET, ContainerOpenPacket.class);
            RegisterPacket(ProtocolInfo.CONTAINER_SET_DATA_PACKET, ContainerSetDataPacket.class);
            RegisterPacket(ProtocolInfo.CRAFTING_DATA_PACKET, CraftingDataPacket.class);
            RegisterPacket(ProtocolInfo.CRAFTING_EVENT_PACKET, CraftingEventPacket.class);
            RegisterPacket(ProtocolInfo.DISCONNECT_PACKET, DisconnectPacket.class);
            RegisterPacket(ProtocolInfo.ENTITY_EVENT_PACKET, EntityEventPacket.class);
            RegisterPacket(ProtocolInfo.ENTITY_FALL_PACKET, EntityFallPacket.class);
            RegisterPacket(ProtocolInfo.EXPLODE_PACKET, ExplodePacket.class);
            RegisterPacket(ProtocolInfo.FULL_CHUNK_DATA_PACKET, FullChunkDataPacket.class);
            RegisterPacket(ProtocolInfo.GAME_RULES_CHANGED_PACKET, GameRulesChangedPacket.class);
            RegisterPacket(ProtocolInfo.HURT_ARMOR_PACKET, HurtArmorPacket.class);
            RegisterPacket(ProtocolInfo.INTERACT_PACKET, InteractPacket.class);
            RegisterPacket(ProtocolInfo.INVENTORY_CONTENT_PACKET, InventoryContentPacket.class);
            RegisterPacket(ProtocolInfo.INVENTORY_SLOT_PACKET, InventorySlotPacket.class);
            RegisterPacket(ProtocolInfo.INVENTORY_TRANSACTION_PACKET, InventoryTransactionPacket.class);
            RegisterPacket(ProtocolInfo.ITEM_FRAME_DROP_ITEM_PACKET, ItemFrameDropItemPacket.class);
            RegisterPacket(ProtocolInfo.LEVEL_EVENT_PACKET, LevelEventPacket.class);
            RegisterPacket(ProtocolInfo.LEVEL_SOUND_EVENT_PACKET, LevelSoundEventPacket.class);
            RegisterPacket(ProtocolInfo.LOGIN_PACKET, LoginPacket.class);
            RegisterPacket(ProtocolInfo.MAP_INFO_REQUEST_PACKET, MapInfoRequestPacket.class);
            RegisterPacket(ProtocolInfo.MOB_ARMOR_EQUIPMENT_PACKET, MobArmorEquipmentPacket.class);
            RegisterPacket(ProtocolInfo.MOB_EQUIPMENT_PACKET, MobEquipmentPacket.class);
            RegisterPacket(ProtocolInfo.MODAL_FORM_REQUEST_PACKET, ModalFormRequestPacket.class);
            RegisterPacket(ProtocolInfo.MODAL_FORM_RESPONSE_PACKET, ModalFormResponsePacket.class);
            RegisterPacket(ProtocolInfo.MOVE_ENTITY_PACKET, MoveEntityPacket.class);
            RegisterPacket(ProtocolInfo.MOVE_PLAYER_PACKET, MovePlayerPacket.class);
            RegisterPacket(ProtocolInfo.PLAYER_ACTION_PACKET, PlayerActionPacket.class);
            RegisterPacket(ProtocolInfo.PLAYER_INPUT_PACKET, PlayerInputPacket.class);
            RegisterPacket(ProtocolInfo.PLAYER_LIST_PACKET, PlayerListPacket.class);
            RegisterPacket(ProtocolInfo.PLAYER_HOTBAR_PACKET, PlayerListPacket.class);
            RegisterPacket(ProtocolInfo.PLAY_SOUND_PACKET, PlaySoundPacket.class);
            RegisterPacket(ProtocolInfo.PLAY_STATUS_PACKET, PlayStatusPacket.class);
            RegisterPacket(ProtocolInfo.REMOVE_ENTITY_PACKET, RemoveEntityPacket.class);
            RegisterPacket(ProtocolInfo.REQUEST_CHUNK_RADIUS_PACKET, RequestChunkRadiusPacket.class);
            RegisterPacket(ProtocolInfo.RESOURCE_PACKS_INFO_PACKET, ResourcePacksInfoPacket.class);
            RegisterPacket(ProtocolInfo.RESOURCE_PACK_STACK_PACKET, ResourcePackStackPacket.class);
            RegisterPacket(ProtocolInfo.RESOURCE_PACK_CLIENT_RESPONSE_PACKET, ResourcePackClientResponsePacket.class);
            RegisterPacket(ProtocolInfo.RESOURCE_PACK_DATA_INFO_PACKET, ResourcePackDataInfoPacket.class);
            RegisterPacket(ProtocolInfo.RESOURCE_PACK_CHUNK_DATA_PACKET, ResourcePackChunkDataPacket.class);
            RegisterPacket(ProtocolInfo.RESOURCE_PACK_CHUNK_REQUEST_PACKET, ResourcePackChunkRequestPacket.class);
            RegisterPacket(ProtocolInfo.RESPAWN_PACKET, RespawnPacket.class);
            RegisterPacket(ProtocolInfo.RIDER_JUMP_PACKET, RiderJumpPacket.class);
            RegisterPacket(ProtocolInfo.SET_COMMANDS_ENABLED_PACKET, SetCommandsEnabledPacket.class);
            RegisterPacket(ProtocolInfo.SET_DIFFICULTY_PACKET, SetDifficultyPacket.class);
            RegisterPacket(ProtocolInfo.SET_ENTITY_DATA_PACKET, SetEntityDataPacket.class);
            RegisterPacket(ProtocolInfo.SET_ENTITY_LINK_PACKET, SetEntityLinkPacket.class);
            RegisterPacket(ProtocolInfo.SET_ENTITY_MOTION_PACKET, SetEntityMotionPacket.class);
            RegisterPacket(ProtocolInfo.SET_HEALTH_PACKET, SetHealthPacket.class);
            RegisterPacket(ProtocolInfo.SET_PLAYER_GAME_TYPE_PACKET, SetPlayerGameTypePacket.class);
            RegisterPacket(ProtocolInfo.SET_SPAWN_POSITION_PACKET, SetSpawnPositionPacket.class);
            RegisterPacket(ProtocolInfo.SET_TITLE_PACKET, SetTitlePacket.class);
            RegisterPacket(ProtocolInfo.SET_TIME_PACKET, SetTimePacket.class);
            RegisterPacket(ProtocolInfo.SERVER_SETTINGS_REQUEST_PACKET, ServerSettingsRequestPacket.class);
            RegisterPacket(ProtocolInfo.SERVER_SETTINGS_RESPONSE_PACKET, ServerSettingsResponsePacket.class);
            RegisterPacket(ProtocolInfo.SHOW_CREDITS_PACKET, ShowCreditsPacket.class);
            RegisterPacket(ProtocolInfo.SPAWN_EXPERIENCE_ORB_PACKET, SpawnExperienceOrbPacket.class);
            RegisterPacket(ProtocolInfo.START_GAME_PACKET, StartGamePacket.class);
            RegisterPacket(ProtocolInfo.TAKE_ITEM_ENTITY_PACKET, TakeItemEntityPacket.class);
            RegisterPacket(ProtocolInfo.TEXT_PACKET, TextPacket.class);
            RegisterPacket(ProtocolInfo.UPDATE_ATTRIBUTES_PACKET, UpdateAttributesPacket.class);
            RegisterPacket(ProtocolInfo.UPDATE_BLOCK_PACKET, UpdateBlockPacket.class);
            RegisterPacket(ProtocolInfo.UPDATE_TRADE_PACKET, UpdateTradePacket.class);
        }
    }
}

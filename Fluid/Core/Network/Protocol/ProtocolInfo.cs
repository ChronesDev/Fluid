using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core.Network.Protocol
{
    public class ProtocolInfo
    {
        /**
         * Actual Minecraft: PE protocol version
         */
        static int CURRENT_PROTOCOL = int.Parse("201"); //plugins can change it

        private List<int> SUPPORTED_PROTOCOLS = new List<int>()
        {
            CURRENT_PROTOCOL
        };

        String MINECRAFT_VERSION = "v1.2.10";
        String MINECRAFT_VERSION_NETWORK = "1.2.10";

        public static byte LOGIN_PACKET = 0x01;
        public static byte PLAY_STATUS_PACKET = 0x02;
        public static byte SERVER_TO_CLIENT_HANDSHAKE_PACKET = 0x03;
        public static byte CLIENT_TO_SERVER_HANDSHAKE_PACKET = 0x04;
        public static byte DISCONNECT_PACKET = 0x05;
        public static byte RESOURCE_PACKS_INFO_PACKET = 0x06;
        public static byte RESOURCE_PACK_STACK_PACKET = 0x07;
        public static byte RESOURCE_PACK_CLIENT_RESPONSE_PACKET = 0x08;
        public static byte TEXT_PACKET = 0x09;
        public static byte SET_TIME_PACKET = 0x0a;
        public static byte START_GAME_PACKET = 0x0b;
        public static byte ADD_PLAYER_PACKET = 0x0c;
        public static byte ADD_ENTITY_PACKET = 0x0d;
        public static byte REMOVE_ENTITY_PACKET = 0x0e;
        public static byte ADD_ITEM_ENTITY_PACKET = 0x0f;
        public static byte ADD_HANGING_ENTITY_PACKET = 0x10;
        public static byte TAKE_ITEM_ENTITY_PACKET = 0x11;
        public static byte MOVE_ENTITY_PACKET = 0x12;
        public static byte MOVE_PLAYER_PACKET = 0x13;
        public static byte RIDER_JUMP_PACKET = 0x14;
        public static byte UPDATE_BLOCK_PACKET = 0x15;
        public static byte ADD_PAINTING_PACKET = 0x16;
        public static byte EXPLODE_PACKET = 0x17;
        public static byte LEVEL_SOUND_EVENT_PACKET = 0x18;
        public static byte LEVEL_EVENT_PACKET = 0x19;
        public static byte BLOCK_EVENT_PACKET = 0x1a;
        public static byte ENTITY_EVENT_PACKET = 0x1b;
        public static byte MOB_EFFECT_PACKET = 0x1c;
        public static byte UPDATE_ATTRIBUTES_PACKET = 0x1d;
        public static byte INVENTORY_TRANSACTION_PACKET = 0x1e;
        public static byte MOB_EQUIPMENT_PACKET = 0x1f;
        public static byte MOB_ARMOR_EQUIPMENT_PACKET = 0x20;
        public static byte INTERACT_PACKET = 0x21;
        public static byte BLOCK_PICK_REQUEST_PACKET = 0x22;
        public static byte ENTITY_PICK_REQUEST_PACKET = 0x23;
        public static byte PLAYER_ACTION_PACKET = 0x24;
        public static byte ENTITY_FALL_PACKET = 0x25;
        public static byte HURT_ARMOR_PACKET = 0x26;
        public static byte SET_ENTITY_DATA_PACKET = 0x27;
        public static byte SET_ENTITY_MOTION_PACKET = 0x28;
        public static byte SET_ENTITY_LINK_PACKET = 0x29;
        public static byte SET_HEALTH_PACKET = 0x2a;
        public static byte SET_SPAWN_POSITION_PACKET = 0x2b;
        public static byte ANIMATE_PACKET = 0x2c;
        public static byte RESPAWN_PACKET = 0x2d;
        public static byte CONTAINER_OPEN_PACKET = 0x2e;
        public static byte CONTAINER_CLOSE_PACKET = 0x2f;
        public static byte PLAYER_HOTBAR_PACKET = 0x30;
        public static byte INVENTORY_CONTENT_PACKET = 0x31;
        public static byte INVENTORY_SLOT_PACKET = 0x32;
        public static byte CONTAINER_SET_DATA_PACKET = 0x33;
        public static byte CRAFTING_DATA_PACKET = 0x34;
        public static byte CRAFTING_EVENT_PACKET = 0x35;
        public static byte GUI_DATA_PICK_ITEM_PACKET = 0x36;
        public static byte ADVENTURE_SETTINGS_PACKET = 0x37;
        public static byte BLOCK_ENTITY_DATA_PACKET = 0x38;
        public static byte PLAYER_INPUT_PACKET = 0x39;
        public static byte FULL_CHUNK_DATA_PACKET = 0x3a;
        public static byte SET_COMMANDS_ENABLED_PACKET = 0x3b;
        public static byte SET_DIFFICULTY_PACKET = 0x3c;
        public static byte CHANGE_DIMENSION_PACKET = 0x3d;
        public static byte SET_PLAYER_GAME_TYPE_PACKET = 0x3e;
        public static byte PLAYER_LIST_PACKET = 0x3f;
        public static byte SIMPLE_EVENT_PACKET = 0x40;
        public static byte TELEMETRY_EVENT_PACKET = 0x41;
        public static byte SPAWN_EXPERIENCE_ORB_PACKET = 0x42;
        public static byte CLIENTBOUND_MAP_ITEM_DATA_PACKET = 0x43;
        public static byte MAP_INFO_REQUEST_PACKET = 0x44;
        public static byte REQUEST_CHUNK_RADIUS_PACKET = 0x45;
        public static byte CHUNK_RADIUS_UPDATED_PACKET = 0x46;
        public static byte ITEM_FRAME_DROP_ITEM_PACKET = 0x47;
        public static byte GAME_RULES_CHANGED_PACKET = 0x48;
        public static byte CAMERA_PACKET = 0x49;
        public static byte BOSS_EVENT_PACKET = 0x4a;
        public static byte SHOW_CREDITS_PACKET = 0x4b;
        public static byte AVAILABLE_COMMANDS_PACKET = 0x4c;
        public static byte COMMAND_REQUEST_PACKET = 0x4d;
        public static byte COMMAND_BLOCK_UPDATE_PACKET = 0x4e;
        public static byte COMMAND_OUTPUT_PACKET = 0x4f;
        public static byte UPDATE_TRADE_PACKET = 0x50;
        public static byte UPDATE_EQUIPMENT_PACKET = 0x51;
        public static byte RESOURCE_PACK_DATA_INFO_PACKET = 0x52;
        public static byte RESOURCE_PACK_CHUNK_DATA_PACKET = 0x53;
        public static byte RESOURCE_PACK_CHUNK_REQUEST_PACKET = 0x54;
        public static byte TRANSFER_PACKET = 0x55;
        public static byte PLAY_SOUND_PACKET = 0x56;
        public static byte STOP_SOUND_PACKET = 0x57;
        public static byte SET_TITLE_PACKET = 0x58;
        public static byte ADD_BEHAVIOR_TREE_PACKET = 0x59;
        public static byte STRUCTURE_BLOCK_UPDATE_PACKET = 0x5a;
        public static byte SHOW_STORE_OFFER_PACKET = 0x5b;
        public static byte PURCHASE_RECEIPT_PACKET = 0x5c;
        public static byte PLAYER_SKIN_PACKET = 0x5d;
        public static byte SUB_CLIENT_LOGIN_PACKET = 0x5e;
        public static byte INITIATE_WEB_SOCKET_CONNECTION_PACKET = 0x5f;
        public static byte SET_LAST_HURT_BY_PACKET = 0x60;
        public static byte BOOK_EDIT_PACKET = 0x61;
        public static byte NPC_REQUEST_PACKET = 0x62;
        public static byte PHOTO_TRANSFER_PACKET = 0x63;
        public static byte MODAL_FORM_REQUEST_PACKET = 0x64;
        public static byte MODAL_FORM_RESPONSE_PACKET = 0x65;
        public static byte SERVER_SETTINGS_REQUEST_PACKET = 0x66;
        public static byte SERVER_SETTINGS_RESPONSE_PACKET = 0x67;
        public static byte SHOW_PROFILE_PACKET = 0x68;
        public static byte SET_DEFAULT_GAME_TYPE_PACKET = 0x69;
        public static byte BATCH_PACKET = (byte)0xff;
    }
}

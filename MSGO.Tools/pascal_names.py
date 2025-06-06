import re

data = """
proto_battle_client::recv_examination_progress_r 
proto_battle_client::recv_daily_record_progress_r 
proto_battle_client::recv_netcafe_challenge_progress_r 
proto_battle_client::recv_check_progress_quest_r 
proto_battle_client::recv_demolition_breakthrough_result 
proto_battle_client::recv_map_event_fog_change 
proto_battle_client::recv_map_event_linkfx_change 
proto_battle_client::recv_gm_camera_change_r 
proto_battle_client::recv_cpf_authenticate 
proto_battle_client::recv_cpf_authenticate_error 
proto_battle_client::recv_system_message 
proto_battle_client::recv_debug_message 
proto_battle_client::recv_setmsparam 
proto_battle_client::recv_setwpnparam 
proto_battle_client::recv_module_val_update 
proto_battle_client::recv_module_toggle_point 
proto_battle_client::recv_module_toggle_time 
proto_battle_client::recv_module_toggle_level 
proto_battle_client::recv_shield_any_damage 
proto_battle_client::recv_chara_effect 
proto_battle_client::recv_wrestle_chase_move_start_r 
proto_battle_client::recv_wrestle_chase_move_end_r 
proto_battle_client::recv_area_over_penalty_countdown 
proto_battle_client::recv_mission_safety_area_return_to_area 
proto_battle_client::recv_mission_safety_area_over_penalty 
proto_battle_client::recv_custommatch_room_begin_r 
proto_battle_client::recv_custommatch_room_breakup_r 
"""

# optional manual acronym fix map
acronyms = {
    "cpf": "CPF",
    "gm": "GM",
    "id": "ID",
    "wpn": "Wpn",
    "ms": "Ms",
    "setmsparam": "SetMsParam",
    "setwpnparam": "SetWpnParam",
    "custommatch": "CustomMatch",
}

def to_pascal_case(line):
    name = line.split("::")[-1]
    name = re.sub(r'_r$', '', name)  # remove trailing _r
    if name in acronyms:
        return acronyms[name] + "Request"
    parts = name.split('_')
    return ''.join(acronyms.get(p, p.capitalize()) for p in parts) + 'Request'

lines = data.strip().splitlines()
for line in lines:
    print(to_pascal_case(line.strip()))

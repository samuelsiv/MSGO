import idautils, idc, ida_funcs, idaapi, ida_allins, ida_name, ida_bytes, ida_ida

def xrefs(ea):
    xref_locs = []
    for xref in idautils.XrefsTo(ea):
        xref_locs.append(xref)

    return xref_locs

def get_packet_id_for_send_function(functionAddy):
    f = ida_funcs.get_func(functionAddy)

    packetId = None
    insnadd = None
    for ea in idautils.Heads(f.start_ea, f.end_ea):
        insn = idaapi.insn_t()
        length = idaapi.decode_insn(insn, ea)
        if insn.itype == ida_allins.NN_mov and insn.Op1.type == idaapi.o_reg and insn.Op2.type == idaapi.o_imm:
            if insn.Op2.value >= 0x1000 and insn.Op2.value <= 0xFFFF:
                packetId = insn.Op2.value
                insnadd = ea
                break

    '''
                else:
                    
                    call    _lambda_9a32fed5bf61b6b509b2d3f6003082a1_::_lambda_9a32fed5bf61b6b509b2d3f6003082a1_(__crt_stdio_stream const &)
    .text:00007FF75A0E90E8 90                                            nop
    .text:00007FF75A0E90E9
    .text:00007FF75A0E90E9                               loc_7FF75A0E90E9:                       ; DATA XREF: .rdata:00007FF75A8697E0↓o
    .text:00007FF75A0E90E9                               ;   try {
    .text:00007FF75A0E90E9 48 8D 4E 1E                                   lea     rcx, [rsi+1Eh]
    .text:00007FF75A0E90ED 48 8D 56 02                                   lea     rdx, [rsi+2]
    .text:00007FF75A0E90F1 48 3B D1                                      cmp     rdx, rcx
    .text:00007FF75A0E90F4 0F 87 96 02 00 00                             ja      loc_7FF75A0E9390
    .text:00007FF75A0E90FA B8 9D 37 00 00                                mov     eax, 379Dh
                    
                    return None
    '''

    return packetId
        
    #print(f"Packet ID for function at {hex(functionAddy)}: {hex(packetId)} at instruction {hex(insnadd)}")

def find_nearest_loc(target_addr):
    current_addr = target_addr
    
    # Walk backwards from target address
    while current_addr != idaapi.BADADDR:
        name = ida_name.get_name(current_addr)
        if name and name.startswith('loc_'):
            return current_addr, name
        
        # Move to previous address
        current_addr = ida_bytes.prev_head(current_addr, ida_ida.inf_get_min_ea())
        
        # Stop if we've gone too far back (optional safety check)
        if target_addr - current_addr > 0x1000:  # Adjust range as needed
            break
    
    return None, None

def get_packet_entries(addr, ignoreReg = False):
    shits = []
    for ea in idautils.Heads(addr - 0x100, addr):
        insn = idaapi.insn_t()
        length = idaapi.decode_insn(insn, ea)
        if length == 0:
                continue

        if insn.itype == ida_allins.NN_cmp:
            if (insn.Op1.type == idaapi.o_reg or ignoreReg) and insn.Op2.type == idaapi.o_imm:
                print(f"Found cmp at {hex(ea)}")
                packetId = insn.Op2.value
                shits.append((ea, packetId))

    return shits

def get_packet_id_for_recv_function(callAppendAddress):
    packetId = None
    calls = []

    for ea in idautils.Heads(callAppendAddress - 0x1000, callAppendAddress):
        insn = idaapi.insn_t()
        length = idaapi.decode_insn(insn, ea)
        if length == 0:
            continue

        if insn.itype == ida_allins.NN_call and insn.Op1.type == idaapi.o_near:
            callee = insn.Op1.addr
            if callee == 0x7FF759FA8BF0 or callee == 0x7FF75A0C3A40:
                calls.append(ea)
            else:
                continue
    

    if len(calls) > 0:
        return 0xBABE
        lastCall = calls[-1]
        print(f"Found call  at {hex(lastCall)}")
        b = find_nearest_loc(lastCall)
        print(f"Nearest loc  is {hex(b[0])} with name {b[1]}")

        # get xrefs to that location
        xrefss = xrefss = xrefs(b[0])
        if len(xrefss) > 1:
            # print all xrefss
            for xref in xrefss:
                print(f"Xref at {hex(xref.frm)} to {hex(xref.to)}")
                
            print(f"found invalid xrefs, using last call address {hex(lastCall)}")
            b = find_nearest_loc(xrefss[0].frm)
            shits = get_packet_entries(b[0], True)
            for a in shits:
                print(f"Found packet ID {hex(a[1])} at {hex(a[0])}")
        else:
            xref = xrefss[0]
            shits = get_packet_entries(xref.frm)
            
        if len(shits) > 0:
            print(f"Found packet ID {hex(shits[-1][1])} at {hex(shits[-1][0])}")
            return shits[-1][1]
        else:
            return 0xBABE
    else:
        return 0xBABE

indicative_func_to_type_map = {
    0x7FF759FA7810: "int32",
    0x7FF759FAA4C0: "int32", # readnum wrapper, func above here 1st
    0x7FF759EA1E10: "string",
    0x7FF759FA74C0: "uint16",
    0x7FF759F6C0F0: "uint32",
    0x7FF759FAA4E0: "uint32", # read_uint32 wrapper, func above here
    0x7FF759EA2D90: "int64",
    0x7FF759FA7670: "enum16",
    0x7FF759FA9FE0: "float32",
    0x7ff759faa330: "unknown-string",
    0x7FF759FAA180: "unknown-string2"
}

def get_name_from_addr(frm):
    callArgs = idaapi.get_arg_addrs(frm)
    if callArgs is None:
        return None
    
    if len(callArgs) < 2:
        return None

    nameOp = idc.get_operand_value(callArgs[1], 1) 
    name = idc.get_strlit_contents(nameOp, -1, idc.STRTYPE_C)
    if name is None:
        return None
    name = name.decode('utf-8')
    return name

def get_all_parameters(callAddress):
    callAddress += idaapi.get_item_size(callAddress)
    f = ida_funcs.get_func(callAddress)
    parameters = []
    for ea in idautils.Heads(callAddress, f.end_ea):
        insn = idaapi.insn_t()
        length = idaapi.decode_insn(insn, ea)
        if length == 0:
            continue

        if insn.itype == ida_allins.NN_call:
            callee = insn.Op1.addr
            if callee != 0x7FF759EA1E10:
                continue

            theType = "unknown"
            unknownCallee = None
            extraParameters = []

            param = get_name_from_addr(ea)
            if param is not None:
                # if param contains a comma ignore it
                if ',' in param:
                    continue

                # if it's ' ) [ ']
                if param.startswith(' ) ['):
                    break

                # it must contain an = sign
                if '=' not in param:
                    continue

                # remove the =
                param = param.split('=')[0].strip()

                # find the next call instruction, and check it's callee
                for next_ea in idautils.Heads(ea + length, f.end_ea):
                    next_insn = idaapi.insn_t()
                    next_length = idaapi.decode_insn(next_insn, next_ea)
                    if next_length == 0:
                        continue

                    if next_insn.itype == ida_allins.NN_call:
                        next_callee = next_insn.Op1.addr
                        if next_callee == 0x7ff75a032da0: # this is just return *a1
                            continue

                        theType = indicative_func_to_type_map.get(next_callee, 'unknown')
                        if theType == 'unknown':
                            unknownCallee = next_callee
                            # the func is a parser of the type, so get params there too
                            params = get_all_parameters(next_callee)
                            if len(params) <= 0:
                                print(f"Unknown callee at {hex(next_callee)} for parameter {param} in function {hex(callAddress)}")
                            else:
                                theType = "struct"
                                extraParameters = params
                        break

                parameters.append({
                    'name': param,
                    'type': theType,
                    'address': ea,
                    'unknownCallee': unknownCallee,
                    'extraParameters': extraParameters
                })

    return parameters

recvs = []
sends = []


def normalize_packet_name(name):
    import re
    match = re.match(r'.*?(proto_.*)\(', name)
    if match:
        return match.group(1)
    return name

def do_analyze(ref, name, dump_file, isRecv):
    if isRecv:
        packetid = get_packet_id_for_recv_function(ref.frm)
        #packetid = 0xBABE
    else:
        packetid = get_packet_id_for_send_function(ref.frm)
        if packetid is None:
            packetid = 0xFFFF  # default to 0xFFFF if not found

    params = get_all_parameters(ref.frm)

    with open(dump_file, 'a') as f:
        f.write(f"{name} ({hex(packetid)}) ({hex(ref.frm)})\n")
        
        def format_parameters(param, indent_level=1):
            indent = "  " * indent_level
            if 'extraParameters' in param and len(param['extraParameters']) > 0:
                #result = f"{indent}{param['type']} {param['name']} // {hex(param['address'])} -> [\n"
                result = f"{indent}{param['type']} {param['name']} -> [\n"
                for extra_param in param['extraParameters']:
                    result += format_parameters(extra_param, indent_level + 1) + "\n"
                result += f"{indent}]"
                return result
            else:
                return f"{indent}{param['type']} {param['name']};"
                #return f"{indent}{param['type']} {param['name']}; // {hex(param['address'])}"
        
        for param in params:
            f.write(format_parameters(param) + "\n")
        
        f.write("\n")

refs = xrefs(0x7FF759EA1E10)
for ref in refs:
    try:
        name = get_name_from_addr(ref.frm)
        if name is None:
            continue

        if name.startswith(")<-_"):
            name = normalize_packet_name(name)
            sends.append(ref.frm)
            do_analyze(ref, name, 'packets_send.txt', False)
        elif name.startswith(")->_"):
            recvs.append(ref.frm)
            name = normalize_packet_name(name)
            do_analyze(ref, name, 'packets_recv.txt', True)
            
    except Exception as e:
        #print(f"Error processing reference {hex(ref.frm)}: {e}")
        # print the traceback for debugging
        import traceback
        traceback.print_exc()
        continue

print("Done")
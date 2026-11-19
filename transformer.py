# -*- coding: utf-8 -*-
import re

with open(r'C:/Users/Van Duc/AppData/Local/hermes/composer-pastes/pasted_content_2026-10-26_05-02-27-205_24c855.txt', 'r', encoding='utf-8') as f:
    code = f.read()

# 1. Replace GClass8 -> GClass4
# In method calls on gclass8_0 / gclass4_0:
# method_4 -> method_2 (int)
# method_5 -> method_3 (bool)
# method_6 -> method_4 (set)
# method_1 -> BDB80B23 (string)
# method_10 -> ED11179C (json)

# 2. Class144 -> Class154
# 3. GClass18.EB2AF72C -> Language.GetValue
# 4. GClass18.smethod_3 -> Language.CD21F0A9
# 5. GClass24.A83252B5 -> MsBoxHelper.Show
# 6. GClass24.smethod_0 -> MsBoxHelper.D41C45AC
# 7. GClass6.D1088987 -> Commom.smethod_23
# 8. GClass6.D39C10A0 -> Commom.A9BCAF05
# 9. GClass6.smethod_55 -> Commom.smethod_96
# 10. GClass6.smethod_29 -> Commom.smethod_35
# 11. B912121A.D7043492 -> Class155.DD225F0D
print('Ready to transform.')

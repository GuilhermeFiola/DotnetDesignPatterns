/*
 * The MIT License
 * Copyright © 2014-2019 Ilkka Seppälä
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Text;
using Builder.src.enums;

namespace Builder.src.entities {
    public sealed class Hero {
        public Profession profession {get; private set; }
        public string name {get; private set; }
        public HairType? hairType {get; private set; }
        public HairColor? hairColor {get; private set; }
        public Armor? armor {get; private set; }
        public Weapon? weapon {get; private set; }

        private Hero(Builder builder) {
            this.profession = builder.profession;
            this.name = builder.name;
            this.hairColor = builder.hairColor;
            this.hairType = builder.hairType;
            this.weapon = builder.weapon;
            this.armor = builder.armor;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("This is a ")
              .Append(EnumExtensions.GetDescription(profession))
              .Append(" named ")
              .Append(name);
            
            if(this.hairColor != null || hairType != null) {
                sb.Append(" with ");
                if (hairColor != null) {
                    sb.Append(EnumExtensions.GetDescription(hairColor)).Append(' ');
                }
                if (hairType != null) {
                    sb.Append(EnumExtensions.GetDescription(hairType)).Append(' ');
                }
                sb.Append(hairType != HairType.BALD ? "hair" : "head");
            }
            if (armor != null) {
                sb.Append(" wearing ")
                  .Append(EnumExtensions.GetDescription(armor));
            }
            if (weapon != null) {
                sb.Append(" and wielding a ")
                  .Append(EnumExtensions.GetDescription(weapon));
            }
            
            sb.Append('.');
            return sb.ToString();
        }

        public class Builder {
            public Profession profession {get; private set; }
            public string name {get; private set; }
            public HairType? hairType {get; private set; }
            public HairColor? hairColor {get; private set; }
            public Armor? armor {get; private set; }
            public Weapon? weapon {get; private set; }

            public Builder(Profession? profession, string name)
            {
                if(profession == null || name == null) {
                    throw new ArgumentNullException("Profession or name can't be null!");
                }

                this.profession = profession.Value;
                this.name = name;
            }

            public Builder withHairType(HairType hairType) {
                this.hairType = hairType;
                return this;
            }

            public Builder withHairColor(HairColor hairColor) {
                this.hairColor = hairColor;
                return this;
            }

            public Builder withArmor(Armor armor) {
                this.armor = armor;
                return this;
            }

            public Builder withWeapon(Weapon weapon) {
                this.weapon = weapon;
                return this;
            }

            public Hero build() {
                return new Hero(this);
            }
        }
    }
}
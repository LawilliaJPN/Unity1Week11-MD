using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PulseObject : ControllShaper2D {
    private void Update() {
        float newInnerRadius = this.shaper2D.outerRadius * this.MinOfOuterRadiusRatio + this.shaper2D.outerRadius * this.DifOfOuterRadiusRatio * this.scriptBGMManager.GetRatioInBeat();
        this.UpdateInnerRadius(newInnerRadius);
    }

    private void UpdateInnerRadius(float newInnerRadius) {
        if (newInnerRadius >= this.shaper2D.outerRadius * this.MaxOfOuterRadiusRatio) {
            this.shaper2D.innerRadius = this.shaper2D.outerRadius * this.MaxOfOuterRadiusRatio;

        } else if (newInnerRadius <= this.shaper2D.outerRadius * this.MinOfOuterRadiusRatio) {
            this.shaper2D.innerRadius = this.shaper2D.outerRadius * this.MinOfOuterRadiusRatio;

        } else {
            this.shaper2D.innerRadius = newInnerRadius;

        }
    }
}
import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';
import Translate, {translate} from '@docusaurus/Translate';
import svg1 from '@site/static/img/We_First.png';
import svg2 from '@site/static/img/Module_System.png';
import svg3 from '@site/static/img/Cooperation.png';
import svg4 from '@site/static/img/listening.png';
import svg5 from '@site/static/img/Content.png';

const FeatureList = [
  {
    title: (
      <Translate id="features.1">
        We are the first!
      </Translate>
    ),
    svg: svg1,
    description: (
      <Translate id="features.1.description">
        The first union of mods for SoR
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.2">
        Module system
      </Translate>
    ),
    svg: svg2,
    description: (
        <Translate id="features.2.description">
        You can disable or enable any module in Union at any time
        </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.3">
        Open for cooperation
      </Translate>
    ),
    svg: svg3,
    description: (
        <Translate id="features.3.description">
        We are open for cooperation with other modders and are ready to make compatibility for mods
        </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.4">
        We listen to the players
      </Translate>
    ),
    svg: svg4,
    description: (
        <Translate id="features.4.description">
        We listen to the ideas of the players and their feedback and based on them we work on ourselves
        </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.5">
        Old content
      </Translate>
    ),
    svg: svg5,
    description: (
        <Translate id="features.5.description">
        Mod-Union includes a lot of old content on the type: SMaD, MTP, aToI, but changed for the better.
        </Translate>
    ),
  },
];

function Feature({svg, title, description}) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <img src={svg} className={styles.featureSvg} alt={title}/>
      </div>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props}/>
          ))}
        </div>
      </div>
    </section>
  );
}
